using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class RegisterRequest
    {
        [Required, MaxLength(70)]
        public string FullName { get; set; }

        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required, MinLength(10)]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string NationalNo { get; set; }

        [Required]
        public int NationalityID { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public bool HasDisease { get; set; }

        public string PersonType { get; set; } = "Subscriber";

        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
