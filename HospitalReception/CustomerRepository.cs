using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HospitalReception
{
    public class CustomerRepository : IRepository<Customer>
    {
        private HospitalContext db;

        public CustomerRepository()
        {
            this.db = new HospitalContext();
        }

        public IEnumerable<Customer> GetList()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer _customer)
        {
            db.Customers.Add(_customer);
        }

        public void Update(Customer _customer)
        {
            db.Entry(_customer).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Customer _customer = db.Customers.Find(id);
            if (_customer != null)
                db.Customers.Remove(_customer);
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
