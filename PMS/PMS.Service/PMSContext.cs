using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Service
{
    public class PMSContext : DbContext
    {
        public PMSContext() : base("DefaultConnection")
        {

        }

        public DbSet<PMSuser> PMSuser { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
    }
}
