//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrunOzellikleri
    {
        public int OzellikID { get; set; }
        public int UrunID { get; set; }
        public string OzellikAdi { get; set; }
        public string OzellikDegeri { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}