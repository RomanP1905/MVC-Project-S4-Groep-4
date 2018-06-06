using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAO_Wagenpark.Models
{
    public class Werkplaats
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WerkplaatsNr { get; set; }
        public string Naam { get; set; }
    }
}