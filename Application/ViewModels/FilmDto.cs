
namespace Application.ViewModels
{
    public class FilmDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Subject { get; set; }
        public string Producer { get; set; }
        public string Director { get; set; }
        public string Note { get; set; }
        public int FilmCategoryID { get; set; }
        public string Country { get; set; }
        public string PosterPath { get; set; }
        public int ReleaseDate { get; set; }
    }
}
