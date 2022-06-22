using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Entity.Student
{
    public class Family
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255,MinimumLength =3)]
        [Required]
        public string Name { get; set; }

        public IList<Student> Students { get; set; }
        public IList<Guardian> Guardians { get; set; }

    }
}
