using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W10Ordibehesht
{
    internal class Pub
    {
        public event Test prntpub;

        public void CallMyMethod()
        {
            prntpub();
        }

        public void CallMyMethod2()
        {
            if (prntpub != null)
                prntpub();

            else
                Console.WriteLine("Null!");

        }

    }
}
