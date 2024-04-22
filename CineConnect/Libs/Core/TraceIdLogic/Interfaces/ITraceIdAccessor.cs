using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TraceIdLogic.Interfaces
{
    public interface ITraceIdAccessor
    {
        string GetValue();
        void WriteValue(string value);
    }
}
