using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Autobattler
{
    public class InfoPanel_Text : MonoBehaviour
    {
        private TextMeshProUGUI textMesh;

        public void AttachText(String content)
        {
            textMesh.text = content;
        }

        public void UnattachText()
        {
            textMesh.text = "";
        }
    }
}
