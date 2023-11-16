using MyStore.Domain;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class CustomerModel
    {
        [Required]
        public int Custid { get; set; }

        [Required]
        public string Companyname { get; set; } = null!;
        [Required]
        public string Contactname { get; set; } = null!;

        [Required]
        public string Contacttitle { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;
      

        [Required]
        [MinLength(5)]
        public string? Postalcode { get; set; }

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;




    }
}
