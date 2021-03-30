using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Student1
{
    public class AppCont : DbContext
    {
        public AppCont() : base("DefaultConnection")
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
