using Practical_12_Test_3.Data;
using System.Web.Mvc;

namespace Practical_12_Test_3.Controllers
{
	public class DesignartionController : Controller
	{
		DatabaseClass db = new DatabaseClass();

		public ActionResult Index()
		{
			return View(db.GiveDesignationDetails());
		}
	}
}