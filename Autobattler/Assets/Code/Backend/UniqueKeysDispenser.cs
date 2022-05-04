using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
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
