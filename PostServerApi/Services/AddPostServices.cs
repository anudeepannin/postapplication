using PostServerApi.Models;
using PostServerApi.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostServerApi.Services
{
    public class AddPostServices: IAddPostServices
    {
        private readonly IAddPostRepository _AddPostRepository;
        public AddPostServices(IAddPostRepository addPostRepository)
        {
            _AddPostRepository = addPostRepository;
        }
        public  Task<List<Post>> GetPostData()
        {
            return _AddPostRepository.GetPosts();
        }
        public Task<Post> InsertPostData(Post p1)
        {
            return _AddPostRepository.CreatePost(p1);
        }

        public Task<Post> UpdatepostData(int id,Post p1)
        {
            return _AddPostRepository.UpdatePost(id,p1);
        }

        public Task<Post> UpdateLike(int id,Post p1)
        {
            return _AddPostRepository.PostLike(id,p1);
        }
        public Task<Post> UpdateHeart(int id,Post p1)
        {
            return _AddPostRepository.PostHeart(id,p1);
        }
    }
}
