using Core.TraceIdLogic.Interfaces;
using Core.TraceLogic.Interfaces;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TraceIdLogic
{
    internal class TraceIdAccessor : ITraceReader, ITraceWriter, ITraceIdAccessor
    {
        public string Name => "TraceID";
        private string _value;

        public string GetValue()
        {
            return _value;
        }

        public void WriteValue(string value)
        {
            _value = value;
            LogContext.PushProperty("TraceID", value);
        }
    }
}
