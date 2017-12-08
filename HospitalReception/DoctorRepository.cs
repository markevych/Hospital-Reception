using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HospitalReception
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private HospitalContext db;

        public DoctorRepository()
        {
            this.db = new HospitalContext();
        }

        public IEnumerable<Doctor> GetList()
        {
            return db.Doctors;
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public void Create(Doctor Doctor)
        {
            db.Doctors.Add(Doctor);
        }

        public void Update(Doctor Doctor)
        {
            db.Entry(Doctor).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Doctor Doctor = db.Doctors.Find(id);
            if (Doctor != null)
                db.Doctors.Remove(Doctor);
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
