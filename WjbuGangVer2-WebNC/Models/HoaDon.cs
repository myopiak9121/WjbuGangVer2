//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WjbuGangVer2_WebNC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.MatHangs = new HashSet<MatHang>();
        }
        public void Add(MatHang newProduct)
        {
            MatHangs.Add(newProduct);
        }
        public void Update_Quantity_Shopping(int id_pro, int quantity)
        {
        }
        public void Remove_CartItem(int id)
        {
        }
        public int Total_Quantity()
        {
            return 0;
        }
        public int MaHD { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoLuong { get; set; }
        public int TongTien { get; set; }
        public int MaPT { get; set; }
        public int AccountID { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatHang> MatHangs { get; set; }
    }
}
