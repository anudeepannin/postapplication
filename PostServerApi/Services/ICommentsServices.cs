using PostServerApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
  public  interface ICommentsServices
    {
        Task<List<Comment>> GetComments(int PostId);
        Task InsertComments(Comment c1);
        Task UpdateCommentsdata(Comment c1);
    }
}
