using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebEr.Models
{
    public partial class TMember
    {
        public int FId { get; set; }
        [DisplayName("帳號")]
        [Required]
        public string FUserId { get; set; }
        [DisplayName("密碼")]
        [Required]
        public string FPwd { get; set; }
        [DisplayName("姓名")]
        [Required]
        public string FName { get; set; }
        [DisplayName("信箱")]
        [Required]
        [EmailAddress]
        public string FEmail { get; set; }
    }
}
