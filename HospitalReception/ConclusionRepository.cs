using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HospitalReception
{
    public class ConclusionRepository : IRepository<Conclusion>
    {
        private HospitalContext db;

        public ConclusionRepository()
        {
            this.db = new HospitalContext();
        }

        public IEnumerable<Conclusion> GetList()
        {
            return db.Conclusions;
        }

        public Conclusion Get(int id)
        {
            return db.Conclusions.Find(id);
        }

        public void Create(Conclusion Conclusion)
        {
            db.Conclusions.Add(Conclusion);
        }

        public void Update(Conclusion Conclusion)
        {
            db.Entry(Conclusion).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Conclusion Conclusion = db.Conclusions.Find(id);
            if (Conclusion != null)
                db.Conclusions.Remove(Conclusion);
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
