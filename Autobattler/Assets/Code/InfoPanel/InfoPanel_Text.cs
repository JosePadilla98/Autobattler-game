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

        private void FillPanel(TextPanelData info)
        {
            title.text = info.title;
            content.text = info.content;

            gameObject.SetActive(true);
        }

        private void EmptyPanel()
        {
            title.text = "";
            content.text = "";

            gameObject.SetActive(false);
        }
    }
}
