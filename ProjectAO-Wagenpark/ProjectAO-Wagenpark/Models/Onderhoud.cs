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
        public DateTime Onderhoudsdatum { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? Kosten { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string Auto_Kenteken { get; set; }

        public int Werkplaats_Werkplaatsnr { get; set; }

        public virtual Auto Auto { get; set; }

        public virtual Werkplaats Werkplaats { get; set; }
    }
}
