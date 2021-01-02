using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IDroneService<T> : IService<T>
    {
        Task<bool> SendMessageWithDirections(string message);
    }
}
