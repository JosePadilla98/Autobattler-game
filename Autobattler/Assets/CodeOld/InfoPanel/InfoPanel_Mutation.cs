using AutobattlerOld.MutationsSystem;
using AutobattlerOld.MutationsSystem.Mutations;
using AutobattlerOld.UnitsListScreen.MutationsHandler.Slots;
using UnityEngine;
using UnityEngine.UI;

namespace AutobattlerOld.InfoPanel
{
    public class InfoPanel_Mutation : InfoPanel_Text
    {
        [SerializeField]
        private Image image;

        private void Awake()
        {
            EmptyPanel();
        }

        protected override void FillPanel(TextPanelData info)
        {
            base.FillPanel(info);
            image.sprite = info.sprite;
        }

        public override void EmptyPanel()
        {
            image.sprite = null;
            base.EmptyPanel();
        }

        public void OnMutationSlotSelected(MonoBehaviour mutation_Slot)
        {
            var slot = (Mutation_BaseSlot)mutation_Slot;
            if (!slot.HasItem)
                return;

            Mutation mutation = slot.getItemContained<MutationView>().mutation;
            var info = new TextPanelData(mutation.Name, mutation.Description, mutation.Sprite);
            FillPanel(info);
        }
    }
}
