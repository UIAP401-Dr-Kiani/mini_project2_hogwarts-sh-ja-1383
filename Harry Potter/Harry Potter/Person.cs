﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthDay { get; set; }
        public enum Gender { male, female }
        public Gender GenderType { get; set; }
        public string FatherName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public enum RaceType
        {
            Half_blood ,
            Pure_blood ,
            Muggle_blood
        }
        public RaceType racetype { get; set; }
    }
}
