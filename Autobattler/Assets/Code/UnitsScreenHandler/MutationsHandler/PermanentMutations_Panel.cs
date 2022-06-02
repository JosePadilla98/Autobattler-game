using System;
using System.Collections.Generic;
using Autobattler.Events;
using Autobattler.InfoPanel;
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
        private PermanentMutation_Slot slotPrefab;
        [SerializeField]
        private MutationView mutationViewPrefab;

        [Header("Events")]
        [SerializeField]
        private GameEvent_Info onMutationSelected;

        private Unit currentUnitAttached;
        private PermanentMutation_Slot[] slots;

        public void AttachUnit(Unit unit)
        {
            if (currentUnitAttached != null)
                SaveChanges(currentUnitAttached);

            DestroyAllChildren();

            LoadUnitData(unit);
            currentUnitAttached = unit;
        }

        public void LoadUnitData(Unit unitToLoad)
        {
            List<Mutation> mutationsList = unitToLoad.permanentMutations;
            slots = new PermanentMutation_Slot[mutationsList.Count];

            for (int i = 0; i < mutationsList.Count; i++)
            {
                var slot = AddNewSlot();
                slots[i] = slot;

                var mutation = mutationsList[i];
                AddNewMutationView(mutation, slot);
            }
        }

        private void SaveChanges(Unit unitModified)
        {
            List<Mutation> mutationsList = unitModified.permanentMutations;
            mutationsList.Clear();

            foreach (var slot in slots)
            {
                mutationsList.Add(slot.MutationContained);
            }
        }

        private PermanentMutation_Slot AddNewSlot()
        {
            var slot = Instantiate<PermanentMutation_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas);
            slot.gameObject.name = "PermanentMutations_Slot_" + slotsParent.childCount;

            return slot;
        }

        private void AddNewMutationView(Mutation mutation, PermanentMutation_Slot slot)
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

        public void OnPermanentMutationSlotSelected(MonoBehaviour permanentMutation_Slot)
        {
            var slot = (PermanentMutation_Slot)permanentMutation_Slot;
            Mutation mutation = slot.getItemContained<MutationView>().mutation;

            TextPanelData infoToSend = new TextPanelData(mutation.Name, mutation.Description);
            onMutationSelected.Raise(infoToSend);
        }

        private void OnDisable()
        {
            if (currentUnitAttached != null)
                SaveChanges(currentUnitAttached);
        }
    }
}