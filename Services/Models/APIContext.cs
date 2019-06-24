using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class APIContext:DbContext
    {
        public DbSet<Product> products { get; set; }

    }
}