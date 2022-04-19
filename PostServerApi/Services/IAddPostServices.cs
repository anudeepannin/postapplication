using PostServerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
    public interface IAddPostServices
    {
        Task<List<Post>> GetPostData();
        Task<Post> InsertPostData(Post p1);
        Task<Post> UpdatepostData(int id,Post p1);
        Task<Post> UpdateLike(int id,Post p1);
        Task<Post> UpdateHeart(int id,Post p1);
    }
}
