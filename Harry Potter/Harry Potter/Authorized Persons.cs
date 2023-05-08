using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Authorized_Persons : Person
    {

        public Lesson[][] Curriculum;

        public enum Pet { rat , cat , owl}
        public Group Group { get; set; }
        public bool HavingSuitcase;
        public enum Job { teacher , student }
        public string Letter { get; set; }


    }
}
