namespace HalisElektronik.Dto
{
    public class SocialMediaCreateDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public ImageDto? Images { get; set; }
    }
}