using System;
using System.Collections.Generic;

#nullable disable

namespace Article.Core.Entities
{
    public partial class Article
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        public long Id { get; set; }
        public string AuthorName { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
