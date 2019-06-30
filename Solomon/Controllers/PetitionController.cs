using Solomon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solomon.Controllers
{
    public class PetitionController : Controller
    {
        // GET: Petition
        public ActionResult Index()
        {
            //Article article 
            return View("Article",);
        }
    }
}