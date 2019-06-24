using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAndErrors
{
    public class LogAndErrorsClass
    {
        public void CatchException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
