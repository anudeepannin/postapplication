using PostServerApi.Models;
using PostServerApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
    public class CommentsServices : ICommentsServices
    {
        private readonly ICommentsRepository _CommentsRepository;
        public CommentsServices(ICommentsRepository CommentsRepository)
        {
            _CommentsRepository = CommentsRepository;
        }
        public Task<List<Comment>> GetComments(int PostId)
        {
           return _CommentsRepository.CommentsGet(PostId);
        }
        public Task<Comment> InsertComments(Comment c1)
        {
            return _CommentsRepository.CreateComment(c1);
        }
        public Task<Comment> UpdateCommentsData( int id,Comment c1)
        {
            return _CommentsRepository.UpdateComment(id,c1);
        }

    }
}
