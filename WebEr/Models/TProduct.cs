using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable
using System.ComponentModel;
namespace WebEr.Models
{
    public partial class TProduct
    {
        public int FId { get; set; }
        [DisplayName("產品編號")]
        public string FPid { get; set; }
        [DisplayName("品名")]
        public string FName { get; set; }
        [DisplayName("單價")]
        public int? FPrice { get; set; }
        [DisplayName("圖示")]
        public string FImg { get; set; }
    }
}
