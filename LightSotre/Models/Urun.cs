namespace LightSotre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Sepet = new HashSet<Sepet>();
            Satici = new HashSet<Satici>();
            Siparis = new HashSet<Siparis>();
        }

        public int UrunId { get; set; }

        [Required]
        [StringLength(50)]
        public string UrunIsim { get; set; }

        public int Kategore_ID { get; set; }

        public double urunFiyat { get; set; }

        public string urunOzellikler { get; set; }

        [StringLength(1000)]
        public string urunImage { get; set; }

        public virtual Kategore Kategore { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sepet> Sepet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satici> Satici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
