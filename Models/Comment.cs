namespace Models
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(string body, int blogId, string creatorId)
        {
            Body = body;
            BlogId = blogId;
            CreatorId = creatorId;
        }

        public string Body { get; set; }

        public int Id { get; set; }

        public string CreatorId { get; set; }

        public int BlogId { get; set; }
    }
}