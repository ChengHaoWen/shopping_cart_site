using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebEr.Models
{
    public partial class TOrder
    {
        public int FId { get; set; }
        [DisplayName("訂單編號")]
        public string FOrderGuid { get; set; }
        [DisplayName("會員帳號")]
        public string FUserId { get; set; }
        [DisplayName("收件人姓名")]
        [Required]
        public string FReceiver { get; set; }
        [DisplayName("收件人信箱")]
        [Required]
        public string FEmail { get; set; }
        [DisplayName("收件人地址")]
        [Required]
        public string FAddress { get; set; }
        [DisplayName("訂單日期")]
        public DateTime? FDate { get; set; }
    }
}
