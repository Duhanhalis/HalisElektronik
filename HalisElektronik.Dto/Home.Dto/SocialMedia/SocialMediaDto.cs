namespace HalisElektronik.Dto
{
    public class SocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int ImageId { get; set; }
        public ImageDto? Images { get; set; }
    }
}