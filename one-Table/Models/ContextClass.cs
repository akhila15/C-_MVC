using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace one_Table.Models
{
    public class ContextClass:DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}