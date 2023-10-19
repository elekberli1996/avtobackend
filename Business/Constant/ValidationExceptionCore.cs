using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public class ValidationExceptionCore:Exception
    {
        public ValidationExceptionCore(string message):base(message)
        {

        }
    }
}
