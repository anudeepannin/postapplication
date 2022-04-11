using PostServerApi.Model;
using PostServerApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
    public class CommentsServices:ICommentsServices
    {
        private readonly ICommentsRepository _CommentsRepository;
        public CommentsServices(ICommentsRepository CommentsRepository)
        {
            _CommentsRepository = CommentsRepository;
        }
        public Task<List<Comment>> GetComments(int PostId)
        {
            try
            {
                return _CommentsRepository.CommentsGet(PostId);
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }
        public Task InsertComments(Comment c1)
        {
            try
            {
                return _CommentsRepository.CreateComment(c1);
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }
        public Task UpdateCommentsdata(Comment c1)
        {
            try
            {
                return _CommentsRepository.UpdateComment(c1);
            }
            catch (Exception )
            {
                throw new Exception("This method is not implemented");
            }
        }

    }
}
