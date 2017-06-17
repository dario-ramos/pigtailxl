using System.IO;
using System.Threading;

namespace PGT_NJCourts.exe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (!File.Exists(@"C:\Temp\NJCourts\Stop.txt"))
            {
                Thread.Sleep(10000);
            }
        }
    }
}
