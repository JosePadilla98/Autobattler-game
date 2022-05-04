using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Auttobattler.Testing
{
    public class Testing : MonoBehaviour
    {
        public Test test;

        void Start()
        {
            test = new Test();
            test.n = "pepe";

            Debug.Log(test.GetHashCode());

            test.n = "antonio";

            Debug.Log(test.GetHashCode());
        }
    }

    [System.Serializable]
    public class Test
    {
        public string n;
    }
}

