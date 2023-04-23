using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Group
    {
        public enum Type
        {
            Hufflepuff ,
            Gryffindor ,
            Ravenclaw ,
            Slytherin
        }
        public int Score { get; set; }
        public List<string> members { get; set; }
        public List<string> quidditch_players { get; set; }
    }
}
