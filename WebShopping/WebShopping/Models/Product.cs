using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopping.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        [Required(ErrorMessage ="商品名を入力してください"),MaxLength(50,ErrorMessage ="50文字以下")]
        public string PName { get; set; }
        [Required(ErrorMessage ="商品の詳細を入力してください")]
        public string Description { get; set; }
        [Required(ErrorMessage ="商品の単価を入力してください"),Range(0.0,100000.0,ErrorMessage ="0～100000の間")]
        public double Price { get; set; }
        [Required(ErrorMessage ="商品の数を入力してください。")]
        public int PNum { get; set; }
        public string Image { get; set; }
        public int PtId { get; set; }
       
        public ProductType ProductType { get; set; }
        //ひとつの商品は複数の写真を含む可能
        public List<ProductImage> ProductImg { get; set; }
        //ひとつの商品は複数のカートに存在可能
        public List<Cart> Carts { get; set; }
        //ひとつの商品は同時に注文される可能
        public List<OrderDetail> OrdDetail { get; set; }
        
       
    }
}