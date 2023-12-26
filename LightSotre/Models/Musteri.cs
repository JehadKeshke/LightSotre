namespace LightSotre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            Siparis = new HashSet<Siparis>();
            Satici = new HashSet<Satici>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int musteriId { get; set; }

        [Required]
        [StringLength(50)]
        public string MusteriIsim { get; set; }

        [StringLength(11)]
        public string MusteriTel { get; set; }

        public string MusteriAdres { get; set; }

        public int UyeNO { get; set; }

        public virtual Login Login { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satici> Satici { get; set; }
    }
}
