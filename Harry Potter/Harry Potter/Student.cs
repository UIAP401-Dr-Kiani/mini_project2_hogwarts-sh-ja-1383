using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Student : Authorized_Persons
    {
        public List<string> passed_units {  get; set; }
        public int Term { get; set; }
        public int RoomNumber { get; set; }
        public DateTime traintime { get; set; }
    }
}
