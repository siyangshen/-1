using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopping.Models
{
    public class Cart
    {
        [Key]
        public int CId { get; set; }
        [DisplayName("数量")]
        [Required(ErrorMessage ="数量を入力してください。")]
        public int Amount { get; set; }
        public int PId { get; set; }
        public Product Product { get; set; }
        public int MemId { get; set; }
        public Member Member { get; set; }

    }
}