using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RC5.Helper;

namespace RC5
{
    class Buffer : ICloneable
    {
        public ulong A { get; set; }

        public ulong B { get; set; }

        public Buffer() { }

        public Buffer(byte[] block)
        {
            if (block.Length != BlockLength)
                throw new Exception("Block isn't correct");

            var byteA = new byte[WordLength];
            var byteB = new byte[WordLength];

            Array.Copy(block, byteA, WordLength);//записуємо половину блоку в А
            Array.Copy(block, WordLength, byteB, 0, WordLength);//Другу половину в Б

            A = BitConverter.ToUInt64(byteA, 0);
            B = BitConverter.ToUInt64(byteB, 0);

        }

        public byte[] ToBytes()
        {
            var block = new List<byte>(BlockLength);

            var a = BitConverter.GetBytes(A);

            var b = BitConverter.GetBytes(B);

            block.AddRange(a);
            block.AddRange(b);

            return block.ToArray();
        }

        public object Clone()
        {
            var result = new Buffer();

            result.A = this.A;

            result.B = this.B;

            return result;
        }

        public static Buffer operator ^(Buffer left, Buffer right)//перевизначена операція XOR
        {
            var result = new Buffer();

            result.A = left.A ^ right.A;

            result.B = left.B ^ right.B;

            return result;
        }
    }
}
