using Practical_12_Test_1.Data;
using Practical_12_Test_1.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Practical_12_Test_1.Controllers
{
	public class HomeController : Controller
	{
		DatabaseConnection db = new DatabaseConnection();

		public ActionResult Index()
		{
			List<Employee> employees = db.FetchDataFromDB();
			return View(employees);
		}

		public ActionResult Create()
		{
			return View(new Employee());
		}

		[HttpPost]
		public ActionResult Create(Employee employee)
		{
			int result = db.AddDataInDataBase(employee);

			ViewBag.Result = result;
			return RedirectToAction("Index");
		}

		public ActionResult UpdateFirstNameToSqlPerson()
		{
			db.UpdateFirstNameToSQLPerson();
			return RedirectToAction("Index");
		}

		public ActionResult UpdateMiddleNameToI()
		{
			db.UpdateMiddleNameToI();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteRowWhichHaveIdLessThanTwo()
		{
			db.DeleteDataWhichHaveLessThanTwoId();
			return RedirectToAction("Index");
		}

		public ActionResult TruncateTable()
		{
			db.TruncateTable();
			return RedirectToAction("Index");
		}

		public ActionResult FillDummyData()
		{
			db.AddDummyData();
			return RedirectToAction("Index");
		}

	}
}