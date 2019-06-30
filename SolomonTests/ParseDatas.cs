using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace SolomonTests {
    [TestClass]
    public class ParseDatas {
        [TestMethod]
        public void ParseSgg()
        {
            var jsonSerializer = new JsonSerializer();

            var path = @"C:\Users\Mikhail\source\repos\Solomon\SolomonTests\appeals_stavropol_with_comments.json";

            //var result = jsonSerializer.Deserialize<>();
        }
    }
}
