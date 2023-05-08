using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Botanical : Lesson
    {
        public List <Plant> plants_term1 { get; set; }
        public List <Plant> plants_term2 { get; set; }
        public List <Plant> plants_term3 { get; set; }
        public List <Plant> plants_term4 { get; set; }
        public List <Plant> all_plants { get; set; }
        public List <Plant> Exercise_plant { get; set; }
    }
}
