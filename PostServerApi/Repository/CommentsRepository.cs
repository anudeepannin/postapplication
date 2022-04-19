using Microsoft.EntityFrameworkCore;
using PostServerApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly bhavnaContext context;
        public CommentsRepository(bhavnaContext context)
        {
            this.context = context;
        }
        public async Task<List<Comment>> CommentsGet(int PostId)
        {
            try
            {
                var CommentList = await context.Comments.Where(s => s.PostId == PostId).ToListAsync();
                return CommentList;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comment> CreateComment(Comment c1)
        {
            try
            {
                c1.CommentsCreatedDate = DateTime.Now;
                c1.CommentsUpdatedDate = null;
                await context.Comments.AddAsync(c1);
                await context.SaveChangesAsync();
                return c1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comment> UpdateComment(int id, Comment c1)
        {
            try
            {
                var commentData = await context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
                if (commentData != null)
                {
                    commentData.CommentText = c1.CommentText;
                    commentData.CommentsUpdatedDate = DateTime.Now;
                    commentData.PostId = c1.PostId;
                    await context.SaveChangesAsync();
                    return commentData;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
