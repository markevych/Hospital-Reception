using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HospitalReception
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
            :base("HospitalDb")
        { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Conclusion> Conclusions { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
