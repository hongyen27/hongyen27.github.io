using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class Account
    {
        
        public long Id { get; set; }
        [Display(Name = "Tên đăng nhập:")]
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập vào nhé!")]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu vào nhé")]
        public string Password { get; set; }
        public string OldPassword { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email vào nhé")]
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Address { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string CompanyId { get; set; }
        public List<Role> Roles { get; set; }

        //THÊM VÀO
        public string TT_Delivers { get; set; }
    }
}
