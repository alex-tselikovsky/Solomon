using System;
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
        public void ParseSgg()
        {
            var path = @"C:\Users\Mikhail\source\repos\SolomonSrc\SolomonTests\one_appeals_stavropol_with_comments.json";

            ArticleParser.ParseArticles(path);
        }
    }
}
