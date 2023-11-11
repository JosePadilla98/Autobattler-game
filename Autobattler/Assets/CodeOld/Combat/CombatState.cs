using System.Collections;
using AutobattlerOld.Events;
using AutobattlerOld.Grid.Logic;
using UnityEngine;

namespace AutobattlerOld.GameControllers.Combat
{
    [CreateAssetMenu(
        fileName = "CombatState",
        menuName = "ScriptableObjects/CombatState",
        order = 0
    )]
    public class CombatState : ScriptableObject
    {
        public Battlefield_F battlefield;
        public FighterTeamsController teamsController;

        public void Init()
        {
            App.instance.StartCoroutine(BattleLoop());
        }

        IEnumerator BattleLoop()
        {
            while (true)
            {
                Debug.Log("Código ejecutado cada segundo");

                // teamsController.Refresh();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
