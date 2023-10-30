namespace Autobattler
{
    public class Stun
    {
        public static readonly float DURATION = 0.08f;
        public static readonly float STUN_YOURSELF_PAYBACK = 0.08f;

        public static float GetDuration(float inputPower) =>
            Debuff.STANDARD_DURATION * DURATION * inputPower;
    }
}
