using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solomon.Helpers;
using Solomon.Models;

namespace Solomon.Controllers
{
    public class PetitionController : Controller
    {
        // GET: Petition
        public ActionResult Index()
        {
            return View();
        }

        public IEnumerable<Article> List()
        {
            return DataSource.Articles.Take(20);
        }
    }
}