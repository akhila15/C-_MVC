using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace one_Table.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string SName { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }
}