using System;
using System.Collections.Generic;

#nullable disable

namespace Article.Core.Entities
{
    public partial class Comment
    {
        public long Id { get; set; }
        public long? ArticleId { get; set; }
        public string CommentContent { get; set; }
        public string CommentWriter { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Article Article { get; set; }
    }
}
