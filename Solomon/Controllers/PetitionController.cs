using Solomon.Models;
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
            Article article = List().FirstOrDefault();
            return View("Article", article);
        }

        public IEnumerable<Article> List()
        {
            return DataSource.Articles.Take(20);
        }

        [HttpGet]
        public ActionResult AddPertition()
        {
            return View("AddArticle", null);
        }

        [HttpPost]
        public ActionResult AddPertition(Article article)
        {
            return View("AddArticle", null);
        }
    }
}