using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LoggedException
    {
        public string ClassName;

        public string Message;

        public string StackTraceString;

        public string Source;

        public LoggedException InnerException;

        public string ParamName;
    }
}
