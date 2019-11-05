using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5;

namespace RC5
{
    static class Helper
    {
        public static readonly int KeyLength = 32;//Bytes довжина ключа


        public static readonly int WordLength = 8;//Bytes довжина слова

        public static readonly int WordLengthBit = 64;//Bit


        public static readonly int BlockLength = 16;//Bytes довжина блоку = довжина слова*2

        public static readonly int BlockLengthBit = 128;//Bit 


        public static readonly int Rounds = 16;//кількість раундів


        public static readonly ulong Pw;

        public static readonly ulong Qw;

        static Helper()
        {
            Pw = BitConverter.ToUInt64(MD5.MD5.HexToBytes("B7E151628AED2A6B"), 0);

            Qw = BitConverter.ToUInt64(MD5.MD5.HexToBytes("9E3779B97F4A7C15"), 0);
        }

        public static ulong BitLoopLeft(ulong bytes, ulong UlongLeftStep)
        {
            int LeftStep = (int)(UlongLeftStep % ((ulong)WordLengthBit));

            int RightStep = WordLengthBit - LeftStep;

            return BitLoop(bytes, LeftStep, RightStep);
        }

        public static ulong BitLoopRight(ulong bytes, ulong UlongRightStep)
        {
            int RightStep = (int)(UlongRightStep % ((ulong)WordLengthBit));

            int LeftStep = WordLengthBit - RightStep;

            return BitLoop(bytes, LeftStep, RightStep);
        }

        private static ulong BitLoop(ulong bytes, int LeftStep, int RightStep)
        {
            ulong left = bytes << LeftStep;
            ulong right = bytes >> RightStep;
            return left | right;
        }
    }
}
