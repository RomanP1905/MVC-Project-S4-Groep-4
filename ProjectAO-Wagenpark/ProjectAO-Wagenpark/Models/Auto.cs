using System.ComponentModel.DataAnnotations;

namespace ProjectAO_Wagenpark.Models
{
    public class Auto
    {
        [Key]
        public string Kenteken { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
    }
}