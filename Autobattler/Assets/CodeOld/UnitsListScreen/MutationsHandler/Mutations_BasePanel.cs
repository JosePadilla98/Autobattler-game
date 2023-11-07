using System;
using System.Collections;
using System.Collections.Generic;
using AutobattlerOld.MutationsSystem;
using AutobattlerOld.MutationsSystem.Mutations;
using AutobattlerOld.Units.Management;
using AutobattlerOld.UnitsListScreen.MutationsHandler.Slots;
using UnityEngine;

namespace AutobattlerOld.UnitsListScreen.MutationsHandler
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
        private Mutation_BaseSlot slotPrefab;

        [SerializeField]
        private MutationView mutationViewPrefab;

        protected Unit currentUnitAttached;
        private List<Mutation_BaseSlot> slots;

        public List<Mutation_BaseSlot> Slots
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
            StartCoroutine(AttachUnitCoroutine(unit));
        }

        private IEnumerator AttachUnitCoroutine(Unit unit)
        {
            DestroyAllChildren();

            yield return null;

            LoadUnitData(unit);
            currentUnitAttached = unit;
        }

        public virtual void LoadUnitData(Unit unitToLoad)
        {
            List<Mutation> mutationsList = GetMutationList(unitToLoad);

            foreach (var mutation in mutationsList)
            {
                var slot = AddNewSlot();
                AddNewMutationView(mutation, slot);
            }
        }

        protected Mutation_BaseSlot AddNewSlot()
        {
            var slot = Instantiate<Mutation_BaseSlot>(slotPrefab, slotsParent);
            slot.InyectDependencies(canvas, this);
            slot.gameObject.name = this.gameObject.name + "_Slot_" + slotsParent.childCount;
            Slots.Add(slot);

            return slot;
        }

        public virtual void SaveChanges()
        {
            List<Mutation> mutationsList = GetMutationList(currentUnitAttached);
            mutationsList.Clear();

            foreach (var slot in Slots)
            {
                if (slot.HasItem)
                    mutationsList.Add(slot.MutationContained);
            }
        }

        private void AddNewMutationView(Mutation mutation, Mutation_BaseSlot slot)
        {
            var mutationView = Instantiate<MutationView>(mutationViewPrefab, slot.transform);
            mutationView.InyectDependences(mutation);
        }

        private void DestroyAllChildren()
        {
            Slots.Clear();

            foreach (Transform child in slotsParent)
            {
                Destroy(child.gameObject);
            }
        }

        public virtual void AttachMutation(Mutation mutation)
        {
            CheckIfAddNewSlot();
            SaveChanges();

            if (
                App.DebugController != null && App.DebugController.unitsScreenDebug.mutationsHandler
            )
                Debug.Log(mutation.Name + " attached in " + gameObject.name);
        }

        public void CheckIfAttachMutation(Mutation mutation)
        {
            if (!GetMutationList(currentUnitAttached).Contains(mutation))
                AttachMutation(mutation);
        }

        public virtual void UnattachMutation(Mutation mutation)
        {
            RemoveEmptySlot();
            SaveChanges();

            if (
                App.DebugController != null && App.DebugController.unitsScreenDebug.mutationsHandler
            )
            {
                Debug.Log(mutation.Name + " unattached in in " + gameObject.name);
            }
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

        private Mutation_BaseSlot GetFirstEmptySlot()
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
