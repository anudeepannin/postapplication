using Microsoft.Extensions.Configuration;
using postapi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace postapi.Repository
{
    public interface IAddPostRepository
    {
        List<Post> GetPosts();
        void CreatePost(Post p1);
        void UpdatePost(Post p1);
        void POSTLIKE(Post p1);
        void POSTHEART(Post p1);
    }
}
