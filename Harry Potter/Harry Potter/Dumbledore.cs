using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Dumbledore : Authorized_Persons
    {
        public List<Dormitory> dormitories { get; set; }
        public string username = "Dumbeldore";
        public string password = "dambel_pass";
        public List <int> ticket_request_users { get; set; }
        public List <int> back_ticket_request_users { get; set; }
        public List <Lesson> alllessons { get; set; }
        public List <Plant> reqplnt { get; set; }
    }
}
