using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJCourts.Models
{
    public class County
    {
        public bool Processed { get; set; }

        public bool Selected { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }
    }
}
