using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopping.Models
{
    [DisplayName("カテゴリー")]
    [DisplayColumn("Name")]
    public class ProductType
    {
        [Key]
        public int PtId { get; set; }
        [DisplayName("すべてのカテゴリー")]
        [Required(ErrorMessage ="商品のカテゴリーを入力してください。")]
        public string PtName { get; set; }
        //ひとつのカテゴリーに複数の商品を含む可能
        public List<Product> Products { get; set; }
    }
}