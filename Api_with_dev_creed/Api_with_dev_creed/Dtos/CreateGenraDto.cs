namespace Api_with_dev_creed.Dtos
{
    public class CreateGenraDto
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
