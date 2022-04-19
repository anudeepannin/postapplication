using System;
using System.Collections.Generic;

#nullable disable

namespace PostServerApi.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int? PostId { get; set; }
        public DateTime? CommentsCreatedDate { get; set; }
        public DateTime? CommentsUpdatedDate { get; set; }
    }
}
