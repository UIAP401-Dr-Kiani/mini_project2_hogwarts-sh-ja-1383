using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ordibehesht
{
    delegate void Test();
    internal class Program
    {

        static void print()
        {
            Console.WriteLine("delegate...");
        }

        static void Main(string[] args)
        {

            Test n = new Test(print);
            n();

            Ev eve = new Ev();

            // eve += print;









            Console.ReadKey();
        }
        
    }
}
