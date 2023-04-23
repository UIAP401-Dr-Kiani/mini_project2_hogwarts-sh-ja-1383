using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Person : Authorized_Persons
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        enum Gender { Male, Female }
        public string FatherName { get; set; }
        public int UserName { get; set; }
        public int Password { get; set; }
        enum RaceType
        {
            Half_blood ,
            Pure_blood ,
            Muggle_blood
        }
    }
}
