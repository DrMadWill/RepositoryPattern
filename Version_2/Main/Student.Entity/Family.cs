using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Entity.Student
{
    public class Family : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [StringLength(255,MinimumLength =3)]
        [Required]
        public string Name { get; set; }

        [StringLength(7, MinimumLength = 7)]
        [Required]
        public string Code { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;


        public IList<Student> Students { get; set; }
        public IList<Guardian> Guardians { get; set; }

    }
}
