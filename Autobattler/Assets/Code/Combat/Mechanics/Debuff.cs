namespace Autobattler
{
    public class Debuff
    {
        private static readonly int RANDOM_RANGE_MIN = 4;
        private static readonly int RANDOM_RANGE_MAX = 8;
        public static readonly float STANDARD_DURATION = 10f;

        public static float GetRandomValue() =>
            RandomController.Random.Next(RANDOM_RANGE_MIN, RANDOM_RANGE_MAX);
    }
}
