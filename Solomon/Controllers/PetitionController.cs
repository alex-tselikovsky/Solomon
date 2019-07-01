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
        public ActionResult Index( int id=2860)
        {
            Article article = DataSource.Articles.FirstOrDefault(r=>r.number==id);

            ViewBag.Text = article.description;
            Dictionary<string, SpanInfo[]> aiFacts=new Dictionary<string, SpanInfo[]>();
            try
            {
                aiFacts = AIService.GetFacts(article.description);

                ViewBag.Facts = article.description;

                var desc = article.description;
                var i = 0;
                foreach (var fact in aiFacts)
                {
                    foreach (SpanInfo spanInfo in fact.Value)
                    {
                        var oldValue = desc.Substring(
                            spanInfo.span[0],spanInfo.span[1]- spanInfo.span[0]);

                        desc = desc.Replace(
                            oldValue,
                            "<span title =\"" + fact.Key + " ?\" >"+ oldValue
                       
                                + "</ span >");

                        i = spanInfo.span[1];
                    }

                }

                if (!string.IsNullOrEmpty(desc))
                {
                    ViewBag.Text = desc;
                }
            }
            catch (Exception e)
            {
            }
           

            return View("Article", article);
        }

        public IEnumerable<Article> List() {
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

        //public IEnumerable<Article> AutoInsetInfos() {
            

        //}
    }
}