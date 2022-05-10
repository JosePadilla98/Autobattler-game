namespace Auttobattler.Backend
{
    public static class UniqueKeysDispenser
    {
        private static int counter = 0;

        public static int GetNewKey()
        {
            return counter++;
        }
    }
}
