using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Entity.Student
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public Family Family { get; set; }
        public int FamilyId { get; set; }

        [StringLength(255,MinimumLength =3)]
        [Required]
        public string FName { get; set; }
        [StringLength(255, MinimumLength = 3)]
        [Required]
        public string LName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
