using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RabbitMQRpcService.Interfaces
{
    public interface IRpcService
    {
        string Call(string message);
    }
}
