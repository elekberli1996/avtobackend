using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConsern.Logging
{
   public  class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
