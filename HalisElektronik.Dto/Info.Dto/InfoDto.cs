﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalisElektronik.Dto
{
    
    public class InfoDto
    {
        [Key]
        public int InfoId { get; set; }
        [MaxLength(100)]
        public string? HeaderTitle { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string? HeaderDescription { get; set; } = string.Empty;
        [MaxLength(100)]
        public string? InfoTitle { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string? InfoBody { get; set; } = string.Empty;
        [MaxLength(250)]
        public string? InfoMapsUrl { get; set; } = string.Empty;
    }
}