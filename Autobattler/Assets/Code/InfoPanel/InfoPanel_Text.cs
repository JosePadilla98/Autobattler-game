using TMPro;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    public class InfoPanel_Text : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI content;

        public void AttachInfo(TextPanelData info)
        {
            FillPanel(info);
        }

        public void UnattachInfo()
        {
            EmptyPanel();
        }

        protected virtual void FillPanel(TextPanelData info)
        {
            title.text = info.title;
            content.text = info.content;

            gameObject.SetActive(true);
        }

        protected virtual void EmptyPanel()
        {
            title.text = "";
            content.text = "";

            gameObject.SetActive(false);
        }
    }
}
