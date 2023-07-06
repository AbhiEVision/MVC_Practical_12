using Practical_12_Test_3.Data;
using System.Web.Mvc;

namespace Practical_12_Test_3.Controllers
{
	public class HomeController : Controller
	{
		DatabaseClass db = new DatabaseClass();

		public ActionResult Index()
		{
			return View(db.FetchTheEmployees());
		}

		public ActionResult Truncate()
		{
			db.Truncate();
			return RedirectToAction("Index");
		}

		public ActionResult InsertSomeDefaultData()
		{

			db.InsertRecordsInTables();
			return RedirectToAction("Index");
		}

		public ActionResult FetchTheEmployeePerDesignation()
		{
			return View(db.CountByDesignations());
		}

		public ActionResult Query3()
		{
			return View(db.QueryNumber3());
		}

		public ActionResult CreateViewAndShowDataOfThatView()
		{
			return View(db.CreateView());
		}

		public ActionResult CreateTheStoreProcedureForInsertInDesignationTable()
		{
			db.CreateProcToStoreInDesignation();
			return RedirectToAction("Index");
		}

		public ActionResult CreateTheStoreProcedureForInsertInEmployeeTable()
		{
			db.CreateProcToStoreInEmployee();
			return RedirectToAction("Index");
		}

		public ActionResult DesignationWhichHaveMoreThanOneEmployee()
		{
			return View(db.FetchDesignationWhoHaveMoreThanOnEmployee());
		}

		public ActionResult CreateStoredProcedureAndWhichGivesSortDatabyDOB()
		{
			return View(db.CreateProcWhichReturnListOrderByDOB());
		}

		public ActionResult CreateStoredProcedureAndWhichGivesSortDatabyFirstName()
		{
			return View(db.CreateProcWhichReturnListOrderByFirstName());
		}

		public ActionResult MaxSalaryEmployees()
		{
			return View(db.FindEmployeeWhichHaveMaxSalary());
		}

		public ActionResult CreateNonClustredIndex()
		{
			db.CreateNonClusteredIndex();
			return RedirectToAction("Index");
		}

		public ActionResult CreateStoredProcedureToFetchTheDataByDesignationId()
		{
			db.CreateStoredProcedureToFetchTheDataByDesignationId();
			return RedirectToAction("Index");
		}
	}
}