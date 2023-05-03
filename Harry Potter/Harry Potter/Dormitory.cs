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
        private int _floor = 0;
        private int _room = 0;
        private int _bed = 0;
        private int Code = 000;
        public enum Gender { Male , Femaile}
        private static int _code = 000;

        private Gender _gender;
        
        public Dormitory (Group group , Gender gender )
        {
            _group = group;
            this._gender = gender;

            setcode();

        }

        void setcode()
        {
            if (_bed < 4)
            {
                Code++;
            }
            else
            {
                if (_bed == 4)
                {
                    _bed = 0;
                    _room++;
                }
                if (_room == 9)
                {
                    _room = 0;
                    _floor++;
                }
                Code = (_floor*100) + ( _room*10) + (_bed);
            }
        }

    }
}
