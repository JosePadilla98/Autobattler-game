using System;
using System.Collections.Generic;
using Autobattler.Events;
using Autobattler.InfoPanel;
using Autobattler.InventorySystem;
using Autobattler.MutationsSystem;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.UnitsScreenHandler
{
    public abstract class Mutations_BasePanel : MonoBehaviour
    {
        protected abstract List<Mutation> GetMutationList(Unit unit);

        [SerializeField]
        private Transform slotsParent;
        [SerializeField]
        private Canvas canvas;

        [Header("Prefabs")]
        [SerializeField]
        private Mutation_Slot slotPrefab;
        [SerializeField]
        private MutationView mutationViewPrefab;

        [Header("Events")]
        [SerializeField]
        private GameEvent_Info onMutationSelected;

        private Unit currentUnitAttached;
        private List<Mutation_Slot> slots;

        public List<Mutation_Slot> Slots
        {
            get
            {
                if (slots == null)
                    slots = new();

                return slots;
            }
        }

        public void AttachUnit(Unit unit)
        {
            DestroyAllChildren();

            LoadUnitData(unit);
            currentUnitAttached = unit;
        }

        public void LoadUnitData(Unit unitToLoad)
        {
            List<Mutation> mutationsList = GetMutationList(unitToLoad);

            foreach (var mutation in mutationsList)
            {
                var slot = AddNewSlot();
                Slots.Add(slot);
                AddNewMutationView(mutation, slot);
            }
        }

        private Mutation_Slot AddNewSlot()
        {
            var slot = Instantiate<Mutation_Slot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas);
            slot.gameObject.name = "Mutations_Slot_" + slotsParent.childCount;

            return slot;
        }

        private void SaveChanges(Unit unitModified)
        {
            List<Mutation> mutationsList = GetMutationList(unitModified);
            mutationsList.Clear();

            foreach (var slot in Slots)
            {
                mutationsList.Add(slot.MutationContained);
            }
        }

        private void AddNewMutationView(Mutation mutation, Mutation_Slot slot)
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

        public void OnMutationSlotSelected(MonoBehaviour mutation_Slot)
        {
            var slot = (Mutation_Slot)mutation_Slot;
            Mutation mutation = slot.getItemContained<MutationView>().mutation;

            TextPanelData infoToSend = new TextPanelData(mutation.Name, mutation.Description);
            onMutationSelected.Raise(infoToSend);
        }

        public void CheckIfAttachMutation(Mutation mutation)
        {
            if (GetMutationList(currentUnitAttached).Contains(mutation))
            {
                //Player has only change the mutation's cell
                return;
            }

            AttachMutation(mutation);
        }

        private void AttachMutation(Mutation mutation)
        {
            CheckIfAddNewSlot();
            SaveChanges(currentUnitAttached);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.unitsScreenDebug.mutationsHandler)
                Debug.Log(mutation.Name + " attached in " + gameObject.name);

            #endif
        }

        public void UnattachMutation(Mutation mutation)
        {
            RemoveEmptySlot();
            SaveChanges(currentUnitAttached);

            #if UNITY_EDITOR || DEVELOPMENT_BUILD

            if (App.DebugController != null && App.DebugController.inventory.elementsHandler)
                Debug.Log(mutation.Name + " unattached in in " + gameObject.name);

            #endif
        }

        public void CheckIfAddNewSlot()
        {
            if (ElementsCount() != Slots.Count)
                return;

            AddNewSlot();
        }

        public void RemoveEmptySlot()
        {
            if (Slots.Count == 1)
                return;

            var slotToRemove = GetFirstEmptySlot();
            Slots.Remove(slotToRemove);
            Destroy(slotToRemove.gameObject);
        }

        private Mutation_Slot GetFirstEmptySlot()
        {
            foreach (var slot in Slots)
            {
                if (!slot.HasItem)
                    return slot;
            }

            throw new Exception("There is no empty slot in the grid and you are requesting one");
        }

        private int ElementsCount()
        {
            return GetMutationList(currentUnitAttached).Count;
        }
    }
}