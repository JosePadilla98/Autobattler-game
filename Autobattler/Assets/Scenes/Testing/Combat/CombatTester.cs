using AutobattlerOld.Grid;
using AutobattlerOld.LevelSystem;
using UnityEngine;

namespace Autobattler.Test
{
    public class CombatTester : MonoBehaviour
    {
        [SerializeField]
        private InvocationsProcessor invocationsProcessor;

        [Space(20)]
        [SerializeField]
        private InvocationsData playerTestingUnits;

        void Start()
        { //It will only summon units in the player side to test
            invocationsProcessor.SummonUnits(playerTestingUnits, Side.LEFT);
        }
    }
}
