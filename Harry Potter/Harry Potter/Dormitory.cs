using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harry_Potter
{
    internal class Dormitory
    {
        private Group _group;
        public enum Gender { Male , Femaile}

        private Gender _gender;
        
        public Dormitory (Group group , Gender gender )
        {
            _group = group;
            _gender = gender;
        }

        static int code ;
        static int bed = -1;
        static int room = 0;
        static int floor = 0;
        public static int setcode ()
        {
            if (bed <= 4)
            {
                bed++;
            }
            else
            {
                if (bed == 5)
                {
                    bed = 0;
                    room++;
                }
                if (room == 10)
                {
                    room = 0;
                    floor++;
                }
            }

            code = floor*100 + room*10 + bed;
            return code;
        }


    }
}
