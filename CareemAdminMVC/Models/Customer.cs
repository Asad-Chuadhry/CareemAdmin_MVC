//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareemAdminMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customer
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please provide name", AllowEmptyStrings = false)]
        public string name { get; set; }
        public string phoneNo { get; set; }
        public long rides { get; set; }
        public string city { get; set; }
        public long payment { get; set; }
        public System.DateTime date { get; set; }
    }
}