using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace SefimMusteriTakip.DBCodes
{
    [Table("FrmNotlar")]
    public class FrmNotlar
    {
        [Key]
        public int? NotID { get; set; }
        public int? MusteriID { get; set; }
        public string? NotMetni { get; set; }
        public DateTime? NotTarihi { get; set; }
        public bool? YapildiMi { get; set; }

        [ForeignKey("MusteriID")]
        public Musteri Musterisi{ get; set; }
    }
}