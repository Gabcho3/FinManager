using Microsoft.AspNetCore.Mvc;

using FinManager.Core.Models.Transaction;
using FinManager.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using FinManager.Data.Entities;

namespace FinManager.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService service;
        private readonly UserManager<ApplicationUser> userManager;

        private Guid userId => GetUserId();

        public TransactionController(ITransactionService _service, UserManager<ApplicationUser> _userManager)
        {
            this.service = _service;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var pageViewModel = new TransactionPageViewModel()
            {
                AllUserTransactions = await service.GetAllUserTransactionsAsync(userId),
                TransactionViewModel = new TransactionViewModel(),
                TransactionFormModel = new TransactionFormModel()
            };

            return View(pageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TransactionFormModel transaction)
        {
            transaction.UserId = userId;
            if (ModelState.IsValid)
            {
                await service.AddTransactionAsync(transaction);
            }

             return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var transaction = service.GetTransactionById(id);
            var pageViewModel = new TransactionPageViewModel()
            {
                AllUserTransactions = await service.GetAllUserTransactionsAsync(userId),
                TransactionViewModel = transaction,
                TransactionFormModel = new TransactionFormModel()
            };


            return View("Index", pageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TransactionFormModel transaction)
        {
            if (ModelState.IsValid)
            {
                await service.EditTransactionAsync(transaction.Id, transaction);
            }
            else
            {
                return RedirectToAction("Edit", transaction.Id);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteTransactionAsync(id);

            return RedirectToAction("Index");
        }

        private Guid GetUserId() => Guid.Parse(userManager.GetUserId(User)!);
    }
}
