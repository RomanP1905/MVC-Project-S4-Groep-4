namespace ProjectAO_Wagenpark.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Onderhoud")]
    public partial class Onderhoud
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime onderhoudsdatum { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? kosten { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string auto_kenteken { get; set; }

        public int werkplaats_werkplaatsnr { get; set; }

        public virtual Auto Auto { get; set; }

        public virtual Werkplaats Werkplaats { get; set; }
    }
}
