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
        public int Oid { get; set; }
        [Required(ErrorMessage ="お届け先のお名前を入力してください。")]
        public string ContactName { get; set; }
        [Required(ErrorMessage ="連絡先を入力してください。")]
        public string ContactPhone { get; set; }
        [Required(ErrorMessage ="お届け先の住所を入力してください。")]
        public string ContactAddress { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [DisplayName("注文時間")]
        public string BuyOn { get; set; }
        //ひとつのオーダーに複数の商品明細を含む可能
        public List<OrderDetail> OrderDetail { get; set; }
        public string UserName{ get; set; }
        public Member Member { get; set; }


    }
}