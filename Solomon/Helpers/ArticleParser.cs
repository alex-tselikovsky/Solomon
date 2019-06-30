using System.IO;
using System.Web;
using Newtonsoft.Json;
using Solomon.Models;

namespace Solomon.Helpers
{
    public class ArticleParser
    {
        public static Article[] ParseArticles(string path) {
            var jsonSerializer = new JsonSerializer();
            var reader = new JsonTextReader(new StreamReader(path));
            var result = jsonSerializer.Deserialize<Article[]>(reader);

            return result;
        }
    }

    public class DataSource
    {
        private static Article[] _full;

        public static Article[] Articles {
            get {
                if (_full == null) {
                    var mapPath = HttpContext.Current.Server.MapPath("~/Jsons/full_petition.json");

                    _full = ArticleParser.ParseArticles(mapPath);
                }

                return _full;
            }
        }
    }
}