using System;
using System.Collections.Generic;

#nullable disable

namespace PostServerApi.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public string PostTittle { get; set; }
        public string DescriptionOfPost { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? LikesCount { get; set; }
        public int? HeartCount { get; set; }
    }
}
