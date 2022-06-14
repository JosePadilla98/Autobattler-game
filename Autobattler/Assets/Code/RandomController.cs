using System;

namespace Autobattler
{
    public class RandomController
    {
        public static Random random;

        public static void Init()
        {
            random = new Random();
        }

        public static void Init(int seed)
        {
            random = new Random(seed);
        }
    }
}