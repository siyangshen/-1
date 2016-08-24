using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShopping.Models
{
    public class Member
    {
        [Key]
        public int MemId { get; set; }
        [Required(ErrorMessage ="アカウントを入力してください")]
        [RegularExpression(@"^[a-zA-Z]\w{5,15}$",ErrorMessage ="アカウントはアルファベットをはじめ、アルファベットと数字しか入力できない。文字数は5～15")]
            
        public string Account { get; set; }
        [Required(ErrorMessage ="パスワードを入力してください")]
        [RegularExpression(@"^\w{6,15}$",ErrorMessage ="6～15の間")]
        public string Password { get; set; }
        [Required(ErrorMessage ="お名前を入力してください")]
        public string MemName { get; set; }
        [Required(ErrorMessage ="メールアドレスを入力してください")]
        public string Email { get; set; }
        //一人の会員は複数のカートを持つ可能
        public List<Cart> Carts { get; set; }
        //一人の会員は複数の注文を持つ可能
        public List<Order> Orders { get; set; }
       

    }
}