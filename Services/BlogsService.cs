using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class BlogsService
    {

        private readonly BlogsRepository _blogsRepository;

        public BlogsService(BlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }

        internal IEnumerable<Blog> Get()
        {
            return (_blogsRepository.Get());
        }

        internal Blog Get(int id)
        {
            return (_blogsRepository.Get(id));
        }

        internal Blog Create(Blog blog)
        {
            return (_blogsRepository.Create(blog));
        }


        internal Blog Edit(Blog blog)
        {
            throw new NotImplementedException();
        }

        internal Blog Delete(int id)
        {
            Blog original = Get(id);
            _blogsRepository.Delete(id, original.CreatorId);
            return (original);
        }

        internal IEnumerable<CreatorBlog> GetByCreatorId(string id)
        {
            return (_blogsRepository.GetByCreatorId(id));
        }
    }
}