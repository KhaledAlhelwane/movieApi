namespace Api_with_dev_creed.Dtos
{
    public class MovieDtoCreate:MainMovieDto
    {
        // in api aspect the image will be sent as is and it will not be sent as a byte so we have to change the varible to IformFile
        //public byte Poster { get; set; }
        public IFormFile Poster { get; set; }
      
    }
}
