﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace WebShopping.Models
{
    public class ProductImg
    {
        [Key]
        public int Pimgid { get; set; }
        public string ImgUrl { get; set; }
        
        public Color Color { get; set; }
        public int Pid { get; set; }
        public Product Products { get; set; }
    }
}