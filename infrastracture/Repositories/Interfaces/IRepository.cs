using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace infrastracture.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(string id);

        Task<T> Update(T entity);

        Task<T> Delete(string id);
    }
}
