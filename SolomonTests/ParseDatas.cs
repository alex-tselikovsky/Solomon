using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solomon.Helpers;

/*
 * "addressee": null,
        "answerByPost": null,
        "approved": null,
        "author": {
            "name": "Козлитина А В.",
            "id": "5c99e9c113887225c98fe627"
        },
        "authorName": "Козлитина А В.",
        "clientType": 0.0,
        "commentsCount": 0,
        "createdAt": "2019-06-20T06:17:37.930Z",
        "delete": null,
        "deloDate": null,
        "deloId": null,
        "description": "В районе в\/ч в лесу, за Спортмастером , что в Северо-западном районе прорван магистральный водовод.",
        "disapprovedCount": 0,
        "docs": [],
        "esia": null,
        "executors": null,
        "extId": null,
        "extNumber": null,
        "externalExec": null,
        "files": ["103f40b0-9323-11e9-8d10-455bfc3021ab"],
        "fulltext": "undefined, undefined",
        "id": "5d0b250143b35f1075b8d156",
        "images": ["103f40b0-9323-11e9-8d10-455bfc3021ab"],
        "latitude": null,
        "longitude": null,
        "newCount": 0,
        "number": 2872,
        "organization": null,
        "place": null,
        "platform": "Web",
        "public": true,
        "pushesSent": 1.0,
        "rejected": null,
        "rejectionReason": null,
        "rubric": {
            "createdAt": 1493934909042,
            "updatedAt": 1493936032001,
            "id": "590ba33dfb64466513a90141",
            "name": "Коммунальное хозяйство",
            "description": "Коммунальное хозяйство",
            "order": 6
        },
        "sentToDelo": null,
        "sitestatus": 0.0,
        "status": 2,
        "statusConfirmed": 1.0,
        "title": null,
        "unapprovedComments": 0.0,
        "updatedAt": "2019-06-20T10:18:45.765Z",
        "uploaded": 1.0,
        "views": 2.0,
        "category": "Коммунальное хозяйство",
        "comment": "Специалистами МУП \"Водоканал\" устранена утечка в 11 часов, во второй половине дня проведены сварочные работы.",
        "clear_comment": "Специалистами МУП \"Водоканал\" устранена утечка в 11 часов, во второй половине дня проведены сварочные работы."
 */
namespace SolomonTests {
    [TestClass]
    public class ParseDatas {
        [TestMethod]
        public void ParseSgg() {
            var path = @"C:\Users\Mikhail\source\repos\SolomonSrc\SolomonTests\one_appeals_stavropol_with_comments.json";

            ArticleParser.ParseArticles(path);
        }

        [TestMethod]
        public void GetFactsTest() {
            var factsUrl = "http://127.0.0.1:5000/getFacts";
            var articleText =
                "Взыскать с индивидуального предпринимателя Иванова Костантипа Петровича дата рождения 10 января 1970 года, проживающего по адресу город Санкт-Петербург, ул. Крузенштерна, дом 5 8 000 (восемь тысяч) рублей 00 копеей госпошлины в пользу бюджета РФ ООО Рога и копыта";

            var result = AIService.GetFacts(articleText, factsUrl);

            Console.WriteLine(result);
        }

        /*
         * {
    "NamesExtractor": [{
        "span": [43, 71],
        "text": "\u0418\u0432\u0430\u043d\u043e\u0432\u0430 \u041a\u043e\u0441\u0442\u0430\u043d\u0442\u0438\u043f\u0430 \u041f\u0435\u0442\u0440\u043e\u0432\u0438\u0447\u0430"
    }, {
        "span": [157, 169],
        "text": "\u041a\u0440\u0443\u0437\u0435\u043d\u0448\u0442\u0435\u0440\u043d\u0430"
    }],
    "AddressExtractor": [{
        "span": [130, 176],
        "text": "\u0433\u043e\u0440\u043e\u0434 \u0421\u0430\u043d\u043a\u0442-\u041f\u0435\u0442\u0435\u0440\u0431\u0443\u0440\u0433, \u0443\u043b. \u041a\u0440\u0443\u0437\u0435\u043d\u0448\u0442\u0435\u0440\u043d\u0430, \u0434\u043e\u043c 5"
    }],
    "DatesExtractor": [{
        "span": [86, 105],
        "text": "10 \u044f\u043d\u0432\u0430\u0440\u044f 1970 \u0433\u043e\u0434\u0430"
    }],
    "MoneyExtractor": [{
        "span": [177, 207],
        "text": "8 000 (\u0432\u043e\u0441\u0435\u043c\u044c \u0442\u044b\u0441\u044f\u0447) \u0440\u0443\u0431\u043b\u0435\u0439 00"
    }],
    "OrganisationExtractor": [{
        "span": [246, 263],
        "text": "\u041e\u041e\u041e \u0420\u043e\u0433\u0430 \u0438 \u043a\u043e\u043f\u044b\u0442\u0430"
    }],
    "LocationExtractor": [{
        "span": [43, 50],
        "text": "\u0418\u0432\u0430\u043d\u043e\u0432\u0430"
    }, {
        "span": [142, 151],
        "text": "\u041f\u0435\u0442\u0435\u0440\u0431\u0443\u0440\u0433"
    }]
}
         */

        [TestMethod]
        public void GetFactsAndParseTest() {
           
            var articleText = "Взыскать с индивидуального предпринимателя Иванова Костантипа Петровича дата рождения 10 января 1970 года, проживающего по адресу город Санкт-Петербург, ул. Крузенштерна, дом 5 8 000 (восемь тысяч) рублей 00 копеей госпошлины в пользу бюджета РФ ООО Рога и копыта";

            var result = AIService.GetFacts(articleText);

            Console.WriteLine(result);
        }
    }
}
