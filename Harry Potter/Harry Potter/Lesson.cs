using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Lesson
    {
        public List<Student> Students { get; set; }
        public string Time { get; set; }
        public int StudentCount { get; set; }
        public int Capacity { get; set; }
        public int Term { get; set; }
        public string Name { get; set; }
        public int grade { get; set; }
        public Teacher Teacher { get; set; }
    }
}
