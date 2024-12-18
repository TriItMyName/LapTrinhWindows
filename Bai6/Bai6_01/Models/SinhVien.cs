namespace Bai6_01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MSSV { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        public double? DTB { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaKhoa { get; set; }
    }
}
