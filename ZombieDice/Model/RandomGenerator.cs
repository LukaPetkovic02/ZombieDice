using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieDice.Model
{
    public class RandomGenerator
    {
        private static Random randomInstance;
        private static readonly object lockObject = new object();

        private RandomGenerator()
        {
            randomInstance = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (randomInstance == null)
                    {
                        randomInstance = new Random();
                    }
                    return new RandomGenerator();
                }
            }
        }
        public int Next(int minValue, int maxValue)
        {
            return randomInstance.Next(minValue, maxValue);
        }
    }
}
