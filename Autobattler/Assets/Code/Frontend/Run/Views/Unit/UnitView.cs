using Assets.Code.Frontend.Run.Views.Unit.Shapes;
using UnityEngine;

namespace Assets.Code.Frontend.Run.Views.Unit
{
    [RequireComponent(typeof(UnitCombatShape), typeof(UnitMainShape))]
    public class UnitView : MonoBehaviour
    {
        [SerializeField]
        private UnitCombatShape combatScreenView;
    }


}
