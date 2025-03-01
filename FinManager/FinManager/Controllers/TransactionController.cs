using Microsoft.AspNetCore.Mvc;

using FinManager.Core.Models.Transactions;

using FinManager.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using FinManager.Data.Entities;

namespace FinManager.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService service;
        private readonly UserManager<ApplicationUser> userManager;

        public TransactionController(ITransactionService service, UserManager<ApplicationUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TransactionFormModel transaction)
        {
            transaction.UserId = Guid.Parse(userManager.GetUserId(User)!);
            if (ModelState.IsValid)
            {
                await service.AddTransactionAsync(transaction);
            }

            return Index(); // If validation fails, stay on the same page
        }
    }
}
