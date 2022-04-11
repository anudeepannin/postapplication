using PostServerApi.Model;
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
            try 
            {
               
                return _AddPostRepository.GetPosts();
            }
            catch(Exception )
            {
                 throw new Exception(" Post is Not Found");
            }
        }
        public Task InsertPostData(Post p1)
        {
            try
            {
                return _AddPostRepository.CreatePost(p1);
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }

        public Task UpdatepostData(Post p1)
        {
            try
            {
                return _AddPostRepository.UpdatePost(p1);
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }

        public Task UpdateLike(Post p1)
        {
            try
            {
                return _AddPostRepository.POSTLIKE(p1);
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }
        public Task UpdateHeart(Post p1)
        {
            try
            {
                return _AddPostRepository.POSTHEART(p1);
            }
            catch (Exception)
            {
                throw new Exception(" This method is not implemented");
            }
        }
    }
}
