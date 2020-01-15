using TubeRehber.Core.Entity;
using TubeRehber.Core.Service;
using TubeRehber.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TubeRehber.Service.Abstract
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        protected TubeRehberContext _context;

        public BaseService()
        {
            _context = new TubeRehberContext();


        }
        public bool Add(T item)
        {
            try
            {

                _context.Set<T>().Add(item);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Add(List<T> items)
        {
            try
            {
                _context.Set<T>().AddRange(items);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Core.Entity.Enum.Status.Active).ToList();
        }

       

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }
        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }
        public bool Remove(T item)
        {
            try
            {
                item.Status = Core.Entity.Enum.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(Guid id, Guid userID)
        {
            try
            {
                T item = GetByID(id);
                item.Status = Core.Entity.Enum.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(Guid id)
        {
            try
            {
                T item = GetByID(id);
                item.Status = Core.Entity.Enum.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int Save()
        {
            
            return _context.SaveChanges();
        }
        public bool Update(T item)
        {
            try
            {
                T itemToBeUpdated = GetByID(item.ID);
                DbEntityEntry entry = _context.Entry(itemToBeUpdated);
                entry.CurrentValues.SetValues(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid ID)
        {
            try
            {
                T item = GetByID(ID);

                _context.Set<T>().Remove(item);
                return true;
            }
            catch
            {
                return false;
            }

        }

       
        

    }
}
