using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IService<T>
    {
        Task<T> Add(T entity);
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Update(int id, T entity);

        Task<T> Delete(int id);
    }
}
