namespace Solomon.Models
{
    public class Article
    {
        public string comment { get; set; }
        public string clear_comment { get; set; }
        public string category { get; set; }

        public Rubric rubric { get; set; }
        public string description { get; set; }
        public string authorName { get; set; }


        public int status { get; set; }
    }
}