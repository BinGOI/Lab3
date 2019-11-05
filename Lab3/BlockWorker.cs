using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RC5.Helper;

namespace RC5
{
    class BlockWorker
    {
        private Buffer _buffer;

        private byte[] _Key;

        private ulong[] _TemporaryKeys;

        public BlockWorker(Buffer buffer, byte[] Key)
        {
            _buffer = (Buffer)buffer.Clone();

            _Key = Key;

            _CreateTemporaryKeys();
        }

        public Buffer Encrypte()
        {
            _buffer.A += _TemporaryKeys[0];//початкове значення першого слова
            _buffer.B += _TemporaryKeys[1];//початкове значення другого слова

            for (int i = 1; i < Rounds + 1; ++i)
            {
                _buffer.A = BitLoopLeft(_buffer.A ^ _buffer.B, _buffer.B) + _TemporaryKeys[i * 2];

                _buffer.B = BitLoopLeft(_buffer.B ^ _buffer.A, _buffer.A) + _TemporaryKeys[i * 2 + 1];
            }

            return _buffer;
        }

        public Buffer Decrypte()
        {
            for (int i = Rounds; i > 0; --i)
            {
                _buffer.B = BitLoopRight(_buffer.B - _TemporaryKeys[i * 2 + 1], _buffer.A) ^ _buffer.A;

                _buffer.A = BitLoopRight(_buffer.A - _TemporaryKeys[i * 2], _buffer.B) ^ _buffer.B;
            }

            _buffer.A -= _TemporaryKeys[0];
            _buffer.B -= _TemporaryKeys[1];

            return _buffer;
        }

        private void _CreateTemporaryKeys()
        {
            _TemporaryKeys = new ulong[Rounds * 2 + 2];//Масив підключів S

            _TemporaryKeys[0] = Pw;

            for (int i = 1; i < _TemporaryKeys.Length; ++i)//визначаємо елементи підключів ДО змішування
            {
                _TemporaryKeys[i] = _TemporaryKeys[i - 1] + Qw;
            }


            //Перетворення K в L

            var KeyWords = new ulong[_Key.Length / WordLength];//масив ключавих слів L[] довижина = с = b/u

            byte[] buffer = new byte[WordLength];

            for (int i = 0; i < KeyWords.Length; ++i)//перетворення K в L
            {
                Array.Copy(_Key, i * WordLength, buffer, 0, WordLength);

                KeyWords[i] = BitConverter.ToUInt64(buffer, 0);
            }

            ulong A = ulong.MinValue, B = ulong.MinValue;

            //ЗМІШУВАННЯ

            int iterations = 0;//t
            if (_TemporaryKeys.Length > KeyWords.Length)
                iterations = _TemporaryKeys.Length;

            else iterations = KeyWords.Length;

            for (int S_Index = 0, L_Index = 0, i = 0; i < 3 * iterations; ++i)
            {
                _TemporaryKeys[S_Index] = BitLoopLeft(_TemporaryKeys[S_Index] + A + B, 3);

                A = _TemporaryKeys[S_Index];

                S_Index = (S_Index + 1) % _TemporaryKeys.Length;

                KeyWords[L_Index] = BitLoopLeft(KeyWords[L_Index] + A + B, (A + B));

                B = KeyWords[L_Index];

                L_Index = (L_Index + 1) % KeyWords.Length;
            }
        }
    }
}
