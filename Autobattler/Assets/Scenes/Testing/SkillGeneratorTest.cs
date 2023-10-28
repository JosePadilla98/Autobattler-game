using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autobattler.Tests
{
    public class SkillGeneratorTest : MonoBehaviour
    {
        void Start()
        {
            SkillGenerator skillGenerator = new();

            Debug.Log(skillGenerator.Build().Text());
        }
    }
}
