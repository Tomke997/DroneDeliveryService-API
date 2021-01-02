using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using infrastracture.Repositories.Interfaces;

namespace Persistance.Repositories.Interfaces
{
    public interface IDroneRepository<T> : IRepository<T>
    {
        Task<bool> SendMessageWithDirections(string message);
    }
}
