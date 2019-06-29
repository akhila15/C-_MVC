using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_MVC.Models
{
    public class Department_2
    {
        public int Id { get; set; }
        public string DName { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Employee_2> Employee_2 { get; set; }
    }
}