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
        public int Cid { get; set; }
        [DisplayName("数量")]
        [Required(ErrorMessage = "数量を入力してください。")]
        public int Amount { get; set; }
        public int Pid { get; set; }
        public Product Product { get; set; }
        public int Mid { get; set; }
        //public int Mid { get; set; }
        //public Member Mem { get; set; }

    }
}