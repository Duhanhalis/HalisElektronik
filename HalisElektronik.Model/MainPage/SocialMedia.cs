using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HalisElektronik.Models
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

        [ForeignKey(name: nameof(Image))]
        public int ImageId { get; set; }
        public Image? Images { get; set; }
    }
}