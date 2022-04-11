using PostServerApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public interface ICommentsRepository
    {
        Task<List<Comment>> CommentsGet(int PostId);
        Task CreateComment(Comment c1);
        Task UpdateComment(Comment c1);
    }
}
