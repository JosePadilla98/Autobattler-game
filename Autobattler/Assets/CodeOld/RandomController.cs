using System;

namespace AutobattlerOld
{
    public class RandomController
    {
        private static Random random;
        public static Random Random => random ??= Init();

        public static Random Init()
        {
            random = new Random();
            return random;
        }

        public static Random Init(int seed)
        {
            random = new Random(seed);
            return random;
        }
    }
}
