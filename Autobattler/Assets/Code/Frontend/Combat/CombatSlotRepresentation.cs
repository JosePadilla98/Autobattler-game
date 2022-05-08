using Auttobattler.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    public class CombatSlotRepresentation : MonoBehaviour
    {
        private CombatSlot combatSlot;
        private FighterRepresentation fighterRepresentation;

        public void AttachUnitrepresentation(Fighter combatInstance)
        {
            fighterRepresentation = Instantiate(GameAssets.Instance.fighterRepresentation, gameObject.transform);
            fighterRepresentation.AttachCombatInstance(combatInstance);

            if (combatSlot.Side == Side.RIGHT)
            {
                fighterRepresentation.image.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public void AttachToLogic(CombatSlot combatSlot)
        {
            this.combatSlot = combatSlot;
            combatSlot.OnUnitAttached += AttachUnitrepresentation;
        }
    }
}
