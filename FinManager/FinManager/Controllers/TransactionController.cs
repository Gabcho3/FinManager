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
            var allTransactions = await service.GetAllUserTransactionsAsync(userId);

            return View(allTransactions);
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

        private Guid GetUserId() => Guid.Parse(userManager.GetUserId(User)!);
    }
}
