using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W10Ordibehesht
{
    delegate void Test();
    internal class Program
    {
        static void Main(string[] args)
        {
            Pub pub = new Pub();
            pub.prntpub += Sub.Print ;

            pub.CallMyMethod();

            Console.ReadKey();
        }
    }
}
