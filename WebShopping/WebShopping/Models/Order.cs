using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopping.Models
{
    public class Order
    {
        [Key]
        public int OId { get; set; }
        [Required(ErrorMessage ="お届け先のお名前を入力してください。")]
        public string ContactName { get; set; }
        [Required(ErrorMessage ="連絡先を入力してください。")]
        public string ContactPhone { get; set; }
        [Required(ErrorMessage ="お届け先の住所を入力してください。")]
        public string ContactAddress { get; set; }
        public double TotalPrice { get; set; }
        //ひとつのオーダーに複数の商品明細を含む可能
        public List<OrderDetail> OrderDetail { get; set; }
        public int MemId { get; set; }
        public Member Member { get; set; }


    }
}