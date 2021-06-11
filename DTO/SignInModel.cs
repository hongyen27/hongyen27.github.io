using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class SignInModel
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Usr { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string Pwd { get; set; }
        [Display(Name = "Nhớ mật khẩu")]
        public bool Remember { get; set; }
    }
}
