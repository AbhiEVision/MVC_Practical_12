using Practical_12_Test_1.Data;
using System.Web.Mvc;

namespace Practical_12_Test_2.Controllers
{
	public class HomeController : Controller
	{
		DatabaseConnection db = new DatabaseConnection();

		public ActionResult Index()
		{

			return View(db.FetchDataFromDB());
		}

		public JsonResult TotalSalary()
		{
			return Json(db.FindTotalSalaries(), "Json", JsonRequestBehavior.AllowGet);
		}


		public ActionResult Data()
		{
			return View(db.FetchDataWhoHaveNeededRequriement());

		}

		public JsonResult TotalNull()
		{
			return Json(db.TotalNull(), "Json", JsonRequestBehavior.AllowGet);
		}

	}
}