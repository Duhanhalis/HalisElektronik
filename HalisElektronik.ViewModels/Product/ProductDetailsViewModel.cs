﻿using HalisElektronik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty!;
        public string? Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; } = null;
        public Category? Category { get; set; }
        public double? Price { get; set; } = null;
        public bool IsStock { get; set; } = true;
        public DateTime Date_Of_Adjustment { get; set; } = DateTime.Now;
        public string MainPhoto { get; set; } = string.Empty;
        public ICollection<ProductImage>? ProductImages { get; set; }
    }
}