using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAO_Wagenpark.Models
{
    public class Onderhoud
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OnderhoudsDatum { get; set; }
        public int OnderhoudsKosten { get; set; }
    }
}