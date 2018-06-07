namespace ProjectAO_Wagenpark.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Auto")]
    public partial class Auto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auto()
        {
            Onderhoud = new HashSet<Onderhoud>();
        }

        [Key]
        [StringLength(6)]
        public string kenteken { get; set; }

        [StringLength(25)]
        public string merk { get; set; }

        [StringLength(25)]
        public string Type { get; set; }

        public int DEALER_DealerNr { get; set; }

        public virtual Dealer Dealer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Onderhoud> Onderhoud { get; set; }
    }
}
