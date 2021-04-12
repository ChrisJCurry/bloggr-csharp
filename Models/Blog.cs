namespace Models
{
    public class Blog
    {
        public Blog()
        {

        }

        public Blog(string title, string description, string imgUrl, string creatorId)
        {
            Title = title;
            Description = description;
            ImgUrl = imgUrl;
            CreatorId = creatorId;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public string CreatorId { get; set; }

        public int Id { get; set; }
    }

    public class CreatorBlog : Blog
    {
        public Profile Creator { get; set; }
    }
}