using System;
using System.Collections;
using System.Collections.Generic;
using Autobattler.InfoPanel;
using TMPro;
using UnityEngine;

namespace Autobattler
{
    public class InfoPanel_Text : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI content;

        private bool isShowing;

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

            isShowing = true;
            gameObject.SetActive(true);
        }

        private void EmptyPanel()
        {
            title.text = "";
            content.text = "";

            isShowing = false;
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            if (isShowing)
                EmptyPanel();
        }
    }
}
