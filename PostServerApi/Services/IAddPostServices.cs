using PostServerApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
    public interface IAddPostServices
    {
        Task<List<Post>> GetPostData();
        Task  InsertPostData(Post p1);
        Task UpdatepostData(Post p1);
        Task UpdateLike(Post p1);
        Task UpdateHeart(Post p1);
    }
}
