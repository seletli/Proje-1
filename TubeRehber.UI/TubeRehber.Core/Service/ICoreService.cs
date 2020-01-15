using TubeRehber.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TubeRehber.Core.Service
{
    public interface ICoreService<T> where T:CoreEntity
    {
        bool Add(T item);
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        List<T> GetActive();
        T GetByID(Guid id);
        int Save();
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
    }
}
