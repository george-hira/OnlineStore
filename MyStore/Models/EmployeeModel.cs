using MyStore.Domain;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
        public class EmployeeModel
        {
            public int Empid { get; set; }

            [Required]
            [MinLength(5)]
            public string Lastname { get; set; } = null!;

            [Required]
            [MinLength(5)]
            public string Firstname { get; set; } = null!;

            public string Title { get; set; } = null!;

            public string Titleofcourtesy { get; set; } = null!;

            [Required]
            public DateTime Birthdate { get; set; }

            public DateTime Hiredate { get; set; }

            public string Address { get; set; } = null!;

            public string City { get; set; } = null!;

            public string? Region { get; set; }

            public string? Postalcode { get; set; }

            public string Country { get; set; } = null!;
            [Phone]
            public string Phone { get; set; } = null!;

            public int? Mgrid { get; set; }
            [EmailAddress]
            public string Email { get; set; } = null!;
            public virtual ICollection<Employee> InverseMgr { get; set; } = new List<Employee>();

            public virtual Employee? Mgr { get; set; }

            public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        }
    
}
