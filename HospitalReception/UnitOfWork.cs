using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalReception
{
    public class UnitOfWork : IDisposable
    {
        private HospitalContext db = new HospitalContext();
        private CustomerRepository customerRepository;
        private DoctorRepository doctorRepository;
        private ConclusionRepository conclusionRepository;

        public CustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository();
                return customerRepository;
            }
        }

        public DoctorRepository Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository();
                return doctorRepository;
            }
        }

        public ConclusionRepository Conclusions
        {
            get
            {
                if (conclusionRepository == null)
                    conclusionRepository = new ConclusionRepository();
                return conclusionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
