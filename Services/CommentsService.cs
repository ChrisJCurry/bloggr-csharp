using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class CommentsService
    {

        private readonly CommentsRepository _commentsRepository;

        public CommentsService(CommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        internal IEnumerable<Comment> Get()
        {
            return (_commentsRepository.Get());
        }

        internal Comment Get(int id)
        {
            return (_commentsRepository.Get(id));
        }

        internal Comment Create(Comment comment)
        {
            return (_commentsRepository.Create(comment));
        }
    }
}