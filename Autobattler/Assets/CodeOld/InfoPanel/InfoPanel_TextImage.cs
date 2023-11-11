using UnityEngine;
using UnityEngine.UI;

namespace AutobattlerOld.InfoPanel
{
    public class InfoPanel_TextImage : InfoPanel_Text
    {
        [SerializeField]
        private Image image;

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
    }
}
