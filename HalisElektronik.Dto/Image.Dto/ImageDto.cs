using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HalisElektronik.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public EntityType EntityType { get; set; }
    }
}
