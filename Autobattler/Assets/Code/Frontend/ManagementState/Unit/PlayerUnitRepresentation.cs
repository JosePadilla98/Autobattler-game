using UnityEngine;

namespace Auttobattler.Frontend.ManagementState
{
    [RequireComponent(typeof(UnitDragHandler))]
    public class PlayerUnitRepresentation : MonoBehaviour
    {
        private UnitDragHandler dragHandler;

        private void Start()
        {
            dragHandler = GetComponent<UnitDragHandler>();
        }
    }
}
