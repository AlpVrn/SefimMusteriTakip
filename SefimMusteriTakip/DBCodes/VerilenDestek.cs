using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SefimMusteriTakip.DBCodes
{
    [Table("Verilen_Destek")]
    public class VerilenDestek
    {
        [Key]
        public int DestekID { get; set;}
        public int MusteriID { get; set;}
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public string DestekVerenKisi { get; set; }

        [ForeignKey("MusteriID")]
        public Musteri Musterisi { get; set; }
    }
}
