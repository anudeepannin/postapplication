using PostServerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public interface IAddPostRepository
    {
        Task<List<Post>> GetPosts();
        Task<Post> CreatePost(Post p1);
        Task<Post> UpdatePost(int id,Post p1);
        Task<Post> PostLike(int id,Post p1);
        Task<Post> PostHeart(int id,Post p1);
    }
}
