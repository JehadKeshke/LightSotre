namespace LightSotre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Siparis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Siparis()
        {
            Fatura = new HashSet<Fatura>();
            SiparisAdres = new HashSet<SiparisAdres>();
            Urun = new HashSet<Urun>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiparisNo { get; set; }

        public int MusteriId { get; set; }

        public int SaticiNo { get; set; }

        [Required]
        [StringLength(50)]
        public string KaregoId { get; set; }

        public DateTime SiparisTarih { get; set; }

        [Required]
        [StringLength(10)]
        public string SiparisDurum { get; set; }

        public double FiyatTutar { get; set; }

        public DateTime UlastirmaZamani { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Fatura { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Satici Satici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiparisAdres> SiparisAdres { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Urun { get; set; }
    }
}
