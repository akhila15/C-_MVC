using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ajax_MVC.Models
{
    public class Employee_2
    {
        public int Id { get; set; }
        public string EName { get; set; }
        public int Salary { get; set; }
        public int Department_2Id { get; set; }
        public virtual Department_2 Department_2 { get; set; }

    }
}