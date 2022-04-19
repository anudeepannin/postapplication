using PostServerApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
    public interface ICommentsServices
    {
        Task<List<Comment>> GetComments(int PostId);
        Task<Comment> InsertComments(Comment c1);
        Task<Comment> UpdateCommentsData(int id,Comment c1);
    }
}
