using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5
{
    static class Helper
    {
        private static int _Count = 1;

        public static uint GetT()
        {
            long _2to32 = (long)uint.MaxValue + 1;

            var result = (uint)(_2to32 * Math.Abs(Math.Sin(_Count)));

            if (_Count == 64)
            {
                _Count = 1;
            }
            else
            {
                ++_Count;
            }

            return result;
        }

        public static uint BitLoopLeft(uint bytes, int LeftStep)
        {
            if (LeftStep < 0 || LeftStep > 32)
                throw new Exception("Ti Ohyiv");

            int RightStep = 32 - LeftStep;

            uint left = bytes << LeftStep;
            uint right = bytes >> RightStep;

            return left + right;
        }
    }
}
