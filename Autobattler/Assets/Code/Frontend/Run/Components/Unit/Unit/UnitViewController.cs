using Assets.Code.Frontend.UnitView.Unit.ScreenViews;
using UnityEngine;

namespace Assets.Code.Frontend.UnitView.Unit
{
    [RequireComponent(typeof(UnitCombatView), typeof(UnitMainView))]
    public class UnitViewController : MonoBehaviour
    {
        [SerializeField]
        private UnitCombatView combatScreenView;
    }

   
}
