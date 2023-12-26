namespace LightSotre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Odeme")]
    public partial class Odeme
    {
        [StringLength(50)]
        public string OdemeId { get; set; }

        public int SepetNO { get; set; }

        [Required]
        [StringLength(10)]
        public string OdemeSecenek { get; set; }

        public int FauraNO { get; set; }

        public double Tutar { get; set; }

        public virtual Fatura Fatura { get; set; }

        public virtual Sepet Sepet { get; set; }
    }
}
