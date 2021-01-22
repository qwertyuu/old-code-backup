using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forms_pong
{
    public static class time
    {
        static DateTime _globalValue;
        public static DateTime GlobalValue
        {
            get
            {
                return _globalValue;
            }
            set
            {
                _globalValue = value;
            }
        }
        static int _bounceCount;
        public static int bounceCount
        {
            get
            {
                return _bounceCount;
            }
            set
            {
                _bounceCount = value;
            }
        }

    }
}
