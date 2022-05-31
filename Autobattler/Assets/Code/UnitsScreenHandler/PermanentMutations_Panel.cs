using Autobattler.MutationsSystem;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public class PermanentMutations_Panel : MonoBehaviour
    {
        [SerializeField]
        private Transform slotsParent;
        [SerializeField]
        private Canvas canvas;

        [Header("Prefabs")]
        [SerializeField]
        private PermanentsMutations_Slot slotPrefab;
        [SerializeField]
        private MutationView mutationViewPrefab;

        public void AttachUnit(Unit unit)
        {
            DestroyAllChildren();

            foreach (var mutation in unit.permanentMutations)
            {
                var slot = AddNewSlot();
                AddNewMutationView(mutation, slot);
                AddNewSlot();
            }
        }

        private PermanentsMutations_Slot AddNewSlot()
        {
            var slot = Instantiate<PermanentsMutations_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas);
            return slot;
        }

        private void AddNewMutationView(Mutation mutation, PermanentsMutations_Slot slot)
        {
            var mutationView = Instantiate<MutationView>(mutationViewPrefab, slot.transform);
            mutationView.InyectDependences(mutation);
        }

        private void DestroyAllChildren()
        {
            foreach (Transform child in slotsParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}