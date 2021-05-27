using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONU.Model
{
    public class ApplicationDbcontext:DbContext
    {

        public DbSet<User> USers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
      : base(options)
        {
        }

    }
}
