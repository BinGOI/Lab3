using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Random
    {
        private static readonly int Modul = 20;

        private static readonly int A = (int)Math.Pow(5, 3);

        private static readonly int C = 34;

        private static readonly int StartValue = 512;

        //----------------

        private static int _prevValue;

        private List<int> _result;

        static Random()
        {
            _prevValue = StartValue;
        }

        public Random(int amount)
        {
            _result = new List<int>(amount);
        }

        public List<int> Run()//ЗАПОВНЮЄМ??
        {
            for (int i = 0; i < _result.Capacity; ++i)
            {
                _prevValue = (A * _prevValue + C) % Modul;

                _result.Add(_prevValue);
            }
            return _result;
        }

        public byte[] GetBytes()
        {
            var list = Run();//заповнюємо змінну _result(на дожвина_блоку/4) числами до 20 і повертаємо її

            var result = new List<byte>(16);

            foreach (var item in list)
            {
                result.AddRange(BitConverter.GetBytes(item));
            }

            return result.ToArray();//повертаємо масив байтів
        }

        public List<int> Run(int min, int max)
        {
            if (max <= min) throw new Exception("max should be bigger than min");

            double realMediana = Modul / 2;

            int radius = (max - min) / 2;

            int changedMediana = min + radius;

            for (int i = 0; i < _result.Capacity; ++i)
            {
                _prevValue = (A * _prevValue + C) % Modul;

                double proportion = (_prevValue - realMediana) / realMediana;

                int correctValue = (int)(radius * proportion) + changedMediana;

                _result.Add(correctValue);
            }
            return _result;
        }

        private int FindPeriod()
        {
            var set = new HashSet<int>() { StartValue };

            int count = set.Count;

            int value = StartValue;

            for (int i = 0; i < Modul; ++i)
            {
                value = (A * value + C) % Modul;

                set.Add(value);

                if (set.Count == count)
                {
                    ++count;
                    break;
                }

                ++count;
            }

            return count;
        }
    }
}
