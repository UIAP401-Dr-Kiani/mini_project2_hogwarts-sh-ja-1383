using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Dormitory
    {
        public Group Group = new Group();
        Group.Type Grp {  get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public int Bets { get; set; }
        public enum Gender { Male, Female }
    }
}
