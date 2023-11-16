using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class ShipperModel
    {

        public int Shipperid { get; set; }

        [Required]
        public string Companyname { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

    }
}
