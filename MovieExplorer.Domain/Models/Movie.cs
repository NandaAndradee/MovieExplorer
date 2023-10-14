namespace MovieExplorer.Domain.Models
{
    public class Movie : Entity
    {        
        public string Title { get; private set; }
        public string OriginalTitle { get; private set; }
        public string Description { get; private set; }

        public Movie(Guid id, string title, string originalTitle, string description) : base(id)
        {
            Title = title;
            OriginalTitle = originalTitle;
            Description = description;
        }

        public Movie()
        {
        }
    }
}
