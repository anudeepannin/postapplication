using Microsoft.EntityFrameworkCore;
using PostServerApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Repository
{
    public class AddPostRepository : IAddPostRepository
    {
        private readonly bhavnaContext context;
        public AddPostRepository(bhavnaContext context)
        {
            this.context = context;
        }
        public async Task<List<Post>> GetPosts()
        {
            try
            {
                return await context.Posts.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> CreatePost(Post p1)
        {
            try
            {
                p1.CreatedDate = DateTime.Now;
                p1.UpdatedDate = null;
                p1.LikesCount = 0;
                p1.HeartCount = 0;
                context.Posts.Add(p1);
                await context.SaveChangesAsync();
                return p1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> UpdatePost(int id, Post p1)
        {
            try
            {
                var postData = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                if (postData != null)
                {
                    postData.PostTittle = p1.PostTittle;
                    postData.DescriptionOfPost = p1.DescriptionOfPost;
                    postData.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();
                    return await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                }
                else
                {
                    throw new ArgumentException(nameof(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> PostLike(int id, Post p1)
        {
            try
            {
                var postData = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                if (postData != null)
                {
                    postData.LikesCount = p1.LikesCount;
                    await context.SaveChangesAsync();
                    return await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                }
                else
                {
                    throw new ArgumentException(nameof(id));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Post> PostHeart(int id, Post p1)
        {
            try
            {
                var postData = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                if (postData != null)
                {
                    postData.HeartCount = p1.HeartCount;
                    await context.SaveChangesAsync();
                    return await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                }
                else
                {
                    throw new ArgumentException(nameof(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
