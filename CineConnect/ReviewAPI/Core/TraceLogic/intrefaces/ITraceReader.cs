using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TraceLogic.intrefaces
{
    /// <summary>
    /// Чтение трассировочных значений при создании нового scoped
    ///</summary>
    public interface ITraceReader
    {
        string Name { get; }
        void WriteValue(string value);
    }
}
