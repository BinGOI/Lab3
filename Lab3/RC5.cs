using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RC5.Helper;

namespace RC5
{
    public class RC5
    {
        private ArrayOfKeys _keys;//будем тримати тут вхідне повідомлення поділене на блоки, ключі і тд

        public RC5(string key, byte[] input)
        {
            _keys = new ArrayOfKeys(key, input);
        }

        //-----------Encrypte----------

        private byte[] _Encrypte_ECB_OneBlock(byte[] block)
        {
            if (block.Length != BlockLength)
                throw new Exception("Block isn't correct");

            var worker = new BlockWorker(new Buffer(block), _keys._Key);//тут генеруєм масив підключів S

            return worker.Encrypte().ToBytes();
        }

        public byte[] Encrypte_RC5_CBC_Pad()
        {
            var generator = new Lab3.Random(BlockLength / 4);//ліст з типом int на розмір

            Buffer prevBlock = new Buffer(generator.GetBytes());//перше значення це значення IV
            //Buffer prevBlock = new Buffer();//перше значення це значення IV

            var encryptedFile = new List<byte>(BlockLength * _keys.Count + 1);//ліст який буде містити байти утвореного файлу

            encryptedFile.AddRange(_Encrypte_ECB_OneBlock(prevBlock.ToBytes()));//додаємо до вихідного файлу зашифрований блок

            foreach (var block in _keys)
            {
                var currentBlock = new Buffer(block);

                var worker = new BlockWorker(prevBlock ^ currentBlock, _keys._Key);//тут генеруєм масив підключів S

                prevBlock = worker.Encrypte();

                encryptedFile.AddRange(prevBlock.ToBytes());//додаємо до вихідного файлу зашифрований блок
            }

            return encryptedFile.ToArray();
        }

        //-----------Decrypte-----------

        private byte[] _Decrypte_ECB_OneBlock(byte[] block)
        {
            if (block.Length != BlockLength)
                throw new Exception("Block isn't correct");

            var worker = new BlockWorker(new Buffer(block), _keys._Key);

            return worker.Decrypte().ToBytes();
        }

        public byte[] Decrypte_RC5_CBC_Pad()
        {
            var prevBlock = new Buffer(_Decrypte_ECB_OneBlock(_keys.GetAndDeleteFirst()));

            var decryptedFile = new List<byte>(BlockLength * _keys.Count);

            foreach (var block in _keys)
            {
                var currentBlock = new Buffer(block);

                var worker = new BlockWorker(currentBlock, _keys._Key);

                decryptedFile.AddRange((prevBlock ^ worker.Decrypte()).ToBytes());

                prevBlock = currentBlock;
            }

            var lastByte = decryptedFile.Last();

            bool IsAdditiveBytes = true;

            if ((int)lastByte < decryptedFile.Count)
            {
                for (int i = decryptedFile.Count - (int)lastByte; i < decryptedFile.Count; ++i)
                {
                    if (lastByte != decryptedFile[i])
                    {
                        IsAdditiveBytes = false;

                        break;
                    }
                }
            }
            else
            {
                IsAdditiveBytes = false;
            }

            if (IsAdditiveBytes)
            {
                decryptedFile.RemoveRange(decryptedFile.Count - (int)lastByte, (int)lastByte);
            }

            return decryptedFile.ToArray();
        }
    }
}
