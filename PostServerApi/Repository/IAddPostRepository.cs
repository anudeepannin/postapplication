using PostServerApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public interface IAddPostRepository
    {
        Task<List<Post>> GetPosts();
        Task CreatePost(Post p1);
        Task UpdatePost(Post p1);
        Task POSTLIKE(Post p1);
        Task POSTHEART(Post p1);
    }
}
