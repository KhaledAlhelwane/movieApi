namespace Api_with_dev_creed.Dtos
{
    public class MovieDtoUpdate:MainMovieDto
    {
        public IFormFile ?Poster { get; set; }
     }
}
