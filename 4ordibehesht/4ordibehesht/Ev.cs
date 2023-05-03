using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ordibehesht
{
    internal class Ev
    {
        public event Test print;
        void show() { print(); }
    }
}
