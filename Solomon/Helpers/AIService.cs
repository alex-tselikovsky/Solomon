using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Solomon.Models;

namespace Solomon.Helpers {
    public class AIService {
        public static Dictionary<string, SpanInfo[]> GetFacts(string articleText) {
            var factsUrl = "http://127.0.0.1:5000/getFacts";
            var resultStr = GetFacts(articleText, factsUrl);

            var jsonSerializer = new JsonSerializer();
            var reader = new JsonTextReader(new StringReader(resultStr));
            var result = jsonSerializer.Deserialize<Dictionary<string, SpanInfo[]>>(reader);
            return result;
        }

        public static string GetFacts(string articleText, string factsUrl) {
            string json =
                $"{{\"text\":\"{HttpUtility.JavaScriptStringEncode(articleText)}\"}}";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(factsUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) {
                streamWriter.Write(json);
            }

            string result = null;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) {
                result = streamReader.ReadToEnd();
            }

            return result;
        }
    }
}