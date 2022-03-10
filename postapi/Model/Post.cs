using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postapi.Model
{
    public class Post
    {
        public int PostID { get; set; }
        public string PostTittle { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public string DescriptionOfPost { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LikesCount { get; set; }
        public int? HeartCount { get; set; }

    }
}
