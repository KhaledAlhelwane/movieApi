namespace Api_with_dev_creed.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        [MaxLength(2500)]
        public string storyLine { get; set; }
        public byte[]Poster { get; set; }
        public byte GenerId { get; set; }
        public Gener Gener { get; set; }

    }
}
