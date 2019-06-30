using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solomon.Models
{
    public class Petition
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> TopAnswers { get; set; }
        public IEnumerable<string> AutoReplacement { get; set; }
        public string Answer { get; set; }

    }
}