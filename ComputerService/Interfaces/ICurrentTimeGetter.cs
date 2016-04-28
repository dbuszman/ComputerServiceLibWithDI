using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService
{
    public interface ICurrentTimeGetter
    {
        DateTime GetCurrentTime();
    }
}
