using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class CommentsRepository
    {

        public readonly IDbConnection _db;

        public CommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Comment> Get()
        {
            string sql = "SELECT * FROM comments;";
            return (_db.Query<Comment>(sql));
        }

        internal Comment Get(int id)
        {
            string sql = "SELECT * FROM comments WHERE id = @id;";
            return (_db.QueryFirstOrDefault<Comment>(sql, new { id }));
        }

        internal Comment Create(Comment comment)
        {
            string sql = @"
            INSERT INTO comments
            (body, blogId, creatorId)
            VALUES
            (@Body, @BlogId, @creatorId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, comment);
            comment.Id = id;
            return (comment);
        }
    }
}