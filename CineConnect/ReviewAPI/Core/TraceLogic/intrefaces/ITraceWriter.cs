using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TraceLogic.intrefaces
{
    /// <summary>
    /// Запись трассировочных значений при отправке запроса
    /// </summary>
    
    public interface ITraceWriter
    {
        string Name { get; }
        string GetValue();
    }
}
