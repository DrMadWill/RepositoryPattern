using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Entity.Student
{
    public class Guardian
    {
        [Key]
        public int Id { get; set; }

        public Family Family { get; set; }
        public int FamilyId { get; set; }

        public Address Address { get; set; }

        public GuardianType GuardianType { get; set; }
        public int GuardianTypeId { get; set; }
        [Required]
        [StringLength(255,MinimumLength =3)]
        public string FName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string LName { get; set; }
        [Required]
        [StringLength(254,MinimumLength =3)]
        public string Email { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

    }
}
