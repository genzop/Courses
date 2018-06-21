using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic name = "Mosh";
            name = 10;

            int a = 10;
            dynamic b = a;
            long c = b;

        }
    }
}
