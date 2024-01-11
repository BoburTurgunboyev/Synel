using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string PayrollNumber { get; set; }
        public string? Forenames { get; set; }
        public string Surname { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Telephone { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Address2 { get; set; }
        public string? Postcode { get; set; }
        public string? Email { get; set; }
        public string? StartDate { get; set; }
    }
}
