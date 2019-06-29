using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ajax_MVC.Models
{
    public class Dept_Emp_2Context:DbContext
    {
        public DbSet<Employee_2> Employee_2s { get; set; }
        public DbSet<Department_2> Department_2s { get; set; }
    }
}