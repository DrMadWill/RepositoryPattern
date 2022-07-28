using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Entity.Student
{
    public class Address:BaseEntity<int>
    {
        public Guardian Guardian { get; set; }
        [Key, ForeignKey("Guardian")]
        public override int Id { get; set; }
        [Required]
        public string Adress { get; set; }
        public string Adress2 { get; set; }

        [StringLength(10)]
        public int PostCode { get; set; }

    }
}
