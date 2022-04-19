using PostServerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public interface ICommentsRepository
    {
        Task<List<Comment>> CommentsGet(int id);
        Task<Comment> CreateComment(Comment c1);
        Task<Comment> UpdateComment(int id,Comment c1);
    }
}
