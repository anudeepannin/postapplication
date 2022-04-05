using postapi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace postapi.Repository
{
   public interface ICommentsRepository
    {

        List<Comment> CommentsGet(int PostId);
        void CreateComment(Comment c1);
        void UpdateComment(Comment c1);
    }
}
