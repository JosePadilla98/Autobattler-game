using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.Scriptables;
using Auttobattler.Combat;

namespace Auttobattler
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
