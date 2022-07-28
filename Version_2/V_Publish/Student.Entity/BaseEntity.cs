using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Entity
{
    public class BaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }

    }
}
