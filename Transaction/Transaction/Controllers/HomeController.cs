using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Transaction.Service;
using Transaction.ViewModel;

namespace Transaction.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private ITransactionService _transactionService;

		public HomeController(ITransactionService transactionService)
		{
			_transactionService = transactionService;
		}

		public async Task<ActionResult> Index()
		{
			try
			{
				var bankList = await _transactionService.GetBanksList();
				if (bankList.Banks.Count > 0)
				{
					bankList.SelectedBankId = bankList.Banks[0].Id;
				}
				return View(bankList);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Get banks list error");
				return View();
			}
		}

		[HttpPost]
		public async Task<JsonResult> GetBanksList()
		{
			try
			{
				var banks = await _transactionService.GetBanksList();
				return Json(JsonConvert.SerializeObject(banks),
					JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Get banks list error");
				return Json("Get error");
			}
		}

		[HttpPost]
		public async Task<ActionResult> GetBankAccounts(BanksListViewModel model)
		{
			try
			{
				var bank = await _transactionService.GetBankAccountsList(model.SelectedBankId);
				return View("PartialBankAccounts", bank);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Get bank accounts error");
				return View();
			}
		}

		[HttpPost]
		public async Task<JsonResult> GetJsonBankAccounts(BankViewModel bank)
		{
			try
			{
				var result = await _transactionService.GetBankAccountsList(bank.Id);
				return Json(JsonConvert.SerializeObject(result),
						JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Get banks list error");
				return Json("Get error");
			}
		}

		[HttpPost]
		public async Task<JsonResult> CreateTransaction(TransactionViewModel transaction)
		{
			try
			{
				await _transactionService.CreateTransaction(transaction);
				return Json("Transation success created");
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Get banks list error");
				return Json("Transation get errors");
			}
		}
	}
}