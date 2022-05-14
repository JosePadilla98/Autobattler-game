using Autobattler.Assets.Code.Grid.ManagementState;
using Autobattler.Code.Grid.ManagementState;
using Autobattler.Units;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Autobattler.Grid
{
    public class UnitContainerView : MonoBehaviour
    {
        public UnitContainer unitContainer;
        public Battefield_U_View battlefield;

        private void Awake()
        {
            unitContainer.onItemAttached += BuilUnitView;
        }

        private void BuilUnitView()
        {

        }
    }
}