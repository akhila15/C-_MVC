using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace one_Table.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string BName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}