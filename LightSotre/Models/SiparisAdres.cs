namespace LightSotre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SiparisAdres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SipAdreID { get; set; }

        [Required]
        [StringLength(50)]
        public string il { get; set; }

        [Required]
        [StringLength(50)]
        public string ilce { get; set; }

        [Required]
        [StringLength(50)]
        public string Mahalle { get; set; }

        [Required]
        [StringLength(50)]
        public string Ev { get; set; }

        public int SiparisNo { get; set; }

        public virtual Siparis Siparis { get; set; }
    }
}
