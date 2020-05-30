//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Micraft_Task
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public int ProductId { get; set; }
        [DisplayName("Product Code")]
        [Required]
        public string ProductCode { get; set; }
        [DisplayName("Product Name")]
        [Required]
        public string ProductName { get; set; }
        [DataType(DataType.Upload)]
        public string file { get; set; }
        [DisplayName("Product Image")]
        public string ProductImage { get; set; }
        [Required]
        public Nullable<int> Unit { get; set; }
        [Required]
        public Nullable<decimal> Rate { get; set; }
        public string Description { get; set; }
    }
}
