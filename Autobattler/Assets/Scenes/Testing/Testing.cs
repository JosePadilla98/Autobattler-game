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
            test = new Test (2f, 2f);

            Debug.Log(GetPropertyValues(test));
            //PropertyInfo[] info = test.GetType().GetProperties();

            //foreach (PropertyInfo prop in info)
            //{
            //    object propValue = prop.GetValue(test);
            //    Debug.Log(propValue.ToString());
            //    // Do something with propValue
            //}
        }
        private static string GetPropertyValues(System.Object o)
        {
            Type type = o.GetType();
            PropertyInfo[] props = type.GetProperties();
            string str = "{";
            foreach (var prop in props)
            {
                str += (prop.Name + ":" + prop.GetValue(o)) + ",";
            }
            return str.Remove(str.Length - 1) + "}";
        }
    }

    [System.Serializable]
    public class Test
    {
        public float attack { get; set; }
        public float defense { get; set; }

        public Test(float attack, float defense)
        {
            this.attack = attack;
            this.defense = defense;
        }
    }
}

