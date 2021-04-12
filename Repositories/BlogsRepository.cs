using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Models;

namespace Repositories
{
    public class BlogsRepository
    {
        public readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Blog> Get()
        {
            string sql = "SELECT * FROM blogs;";
            return (_db.Query<Blog>(sql));
        }

        internal Blog Get(int id)
        {
            string sql = "SELECT * FROM blogs WHERE id = @id;";
            return (_db.QueryFirstOrDefault<Blog>(sql, new { id }));
        }

        internal Blog Create(Blog blog)
        {
            string sql = @"
            INSERT INTO blogs
            (title, description, imgUrl, creatorId)
            VALUES
            (@Title, @Description, @ImgUrl, @CreatorId);
            SELECT LAST_INSERT_ID();";
            int id = (_db.ExecuteScalar<int>(sql, blog));
            blog.Id = id;
            return blog;
        }

        internal void Delete(int id, string userId)
        {
            string sql = @"DELETE FROM blogs WHERE id = @id AND blog.creator == @userId LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<CreatorBlog> GetByCreatorId(string id)
        {
            string sql = @"
            SELECT
            b.*,
            c.*
            FROM blogs b
            JOIN profiles c ON b.creatorId = c.id
            WHERE b.creator = @id;";
            return (_db.Query<CreatorBlog, Profile, CreatorBlog>(sql, (blog, creator) =>
            {
                blog.Creator = creator;
                return blog;
            }, new { id }, splitOn: "id"));
        }
    }
}