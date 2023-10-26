namespace AutobattlerOld
{
    public static class UniqueKeysDispenser
    {
        private static int counter;

        public static int GetNewKey()
        {
            return counter++;
        }
    }
}