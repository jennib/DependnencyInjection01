using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependnencyInjection01
{
    public class DateTimeService : IDateTimeService
    {
        public string GetDateTimeString()
        {
            return DateTime.Now.ToLongDateString();
        }
            
    }
   
}
