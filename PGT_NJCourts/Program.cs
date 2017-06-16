using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PGT_NJCourts.exe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!File.Exists(@"C:\Temp\NJCourts\Stop.txt"))
            {
                Thread.Sleep(30000);
            }
        }
    }
}
