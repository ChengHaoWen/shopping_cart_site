using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable
using System.ComponentModel;

namespace WebEr.Models
{
    public partial class TOrderDetail
    {
        public int FId { get; set; }
        [DisplayName("訂單編號")]
        public string FOrderGuid { get; set; }
        [DisplayName("會員帳號")]
        public string FUserId { get; set; }
        [DisplayName("產品編號")]
        public string FPid { get; set; }
        [DisplayName("品名")]
        public string FName { get; set; }
        [DisplayName("單價")]
        public int? FPrice { get; set; }
        [DisplayName("訂購數量")]
        public int? FQty { get; set; }
        [DisplayName("是否為定")]
        public string FIsApproved { get; set; }
    }
}
