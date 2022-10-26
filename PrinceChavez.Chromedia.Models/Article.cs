using System;

namespace PrinceChavez.Chromedia.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Story_Title { get; set; }
        public int? Num_Comments { get; set; }
    }

    public class FormattedArticle
    {
        public string Title { get; set; }
        public int Comments { get; set; }
    }
}
