using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postapi.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }

        public int PostID { get; set; }

        public DateTime CommentsCreatedDate { get; set; }

        public DateTime CommentsUpdatedDate { get; set; }
    }

}
