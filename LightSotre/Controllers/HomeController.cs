using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LightSotre.Models;

namespace LightSotre.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();
        public ActionResult Index()
        {
            var urun = db.Urun.Include(u => u.Kategore);
            return View(urun.ToList());
        }


    }
}