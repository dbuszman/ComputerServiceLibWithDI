using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public class CurrentTimeGetter : ICurrentTimeGetter
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Today;
        }
    }
}
