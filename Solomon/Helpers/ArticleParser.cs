using System.IO;
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
}