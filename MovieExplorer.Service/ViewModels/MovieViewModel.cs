using System.ComponentModel;

namespace MovieExplorer.Service.ViewModels
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Título")]
        public string Title { get; set; }

        [DisplayName("Título original")]
        public string OriginalTitle { get; set; }

        [DisplayName("Resumo")]
        public string Description { get; set; }
    }
}
