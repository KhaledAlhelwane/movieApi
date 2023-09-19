namespace Api_with_dev_creed.Dtos
{
    public class MainMovieDto
    {
        [MaxLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        [MaxLength(2500)]
        public string storyLine { get; set; }
        // in api aspect the image will be sent as is and it will not be sent as a byte so we have to change the varible to IformFile
        //public byte Poster { get; set; }
        public byte GenerId { get; set; }
    }
}
