using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SPXFlowWebApiTest.Models
{
    public class SPXFlowDbContext : DbContext
    {
        public SPXFlowDbContext()
            : base("SPXFlowDbConnection")
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}