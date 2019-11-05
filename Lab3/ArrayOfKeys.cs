using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5;
using static RC5.Helper;

namespace RC5
{
    class ArrayOfKeys : IEnumerable<byte[]>
    {
        public byte[] _Key { get; private set; }//ключ переведений в хеш

        private byte[][] _Blocks;//масив для збереження блоків кожен з яких буде відповідати 2*розмір_слова

        public int Count
        {
            get { return _Blocks.Length; }
        }

        public byte[] GetAndDeleteFirst()
        {
            var result = _Blocks[0];

            var blocks = new byte[_Blocks.Length - 1][];

            for (int i = 0; i < blocks.Length; ++i)
            {
                blocks[i] = _Blocks[i + 1];
            }

            _Blocks = blocks;

            return result;
        }

        public ArrayOfKeys(string key, byte[] input)
        {
            //---------Key--------------

            var md5 = new MD5.MD5();

            var Key = new List<byte>(KeyLength);

            var hash = md5.GetHash(key);//отримуємо хеш з введеного користувачем ключа

            Key.AddRange(hash);//додаємо утворений хеш в ліст

            Key.AddRange(md5.GetHash(BitConverter.ToString(hash)));//і додаємо ще хеш від хешу тому що в нас довжина ключа 32 байта

            _Key = Key.ToArray();//перетворюємо ліст в масив

            //----------Blocks--------------

            int blocksCount = input.Length / Helper.BlockLength;//дізнаємось кількість блоків

            if (input.Length % Helper.BlockLength != 0)//додаємо ще один блок, для тих байтів що лишилиь
            {
                blocksCount += 1;
            }

            uint additiveBytes = (uint)(Helper.BlockLength - (input.Length % Helper.BlockLength));//скількома байтами потрібно дозаповнити останній блок
            _Blocks = new byte[blocksCount][];
            for (int i = 0; i < _Blocks.Length - 1; ++i)//записуємо кожен блок в окремий елемент двохвимірного масиву "_Blocks"
            {
                _Blocks[i] = new byte[Helper.BlockLength];

                Array.Copy(input, i * Helper.BlockLength, _Blocks[i], 0, Helper.BlockLength);
            }

            var lastBlock = new byte[Helper.BlockLength];

            if (additiveBytes == Helper.BlockLength)//якщо останній блок дорівнює довжині слова
            {
                Array.Copy(input, (_Blocks.Length - 1) * Helper.BlockLength,
                   lastBlock, 0, Helper.BlockLength);

            }
            else if (additiveBytes != Helper.BlockLength)//якщо останній блок недорівнює довжині слова
            {
                Array.Copy(input, (_Blocks.Length - 1) * Helper.BlockLength,
                    lastBlock, 0, Helper.BlockLength - additiveBytes);

                byte additive = BitConverter.GetBytes(additiveBytes).First();

                for (int i = Helper.BlockLength - (int)additiveBytes; i < Helper.BlockLength; ++i)
                {
                    lastBlock[i] = additive;
                }
            }

            _Blocks[_Blocks.Length - 1] = lastBlock;//додаємо останній блок
        }

        public IEnumerator<byte[]> GetEnumerator()
        {
            foreach (var block in _Blocks)
            {
                yield return block;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}