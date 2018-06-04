using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAO_Wagenpark.Models
{
    public class Dealer
    {      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealerNR { get; set; }
        public string Naam { get; set; }
    }
}