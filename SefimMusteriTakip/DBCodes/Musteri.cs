using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SefimMusteriTakip.DBCodes
{
    [Table("Musteriler")]
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }
        public string? Sirket { get; set; }
        public string? Ad { get; set; }
        public string? TCVKN { get; set; }
        public string? Adres { get; set; }
        public string? Telefon { get; set; }
        public string? Email { get; set; }
        public string? Anydesk { get; set; }
        public DateTime? SozlesmeTarihi { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public string? CariTuru { get; set; }
        public bool Silindi { get; set; }
    }
}