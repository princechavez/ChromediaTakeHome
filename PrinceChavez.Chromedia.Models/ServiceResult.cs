using System;
using System.Collections.Generic;
using System.Text;

namespace PrinceChavez.Chromedia.Models
{
    public class ArticleServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public List<FormattedArticle> Articles { get; set; }
    }
}
