using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJCourts.Models
{
    public class ProcessMonitor
    {
        public event Action ProcessStopped;
    }
}
