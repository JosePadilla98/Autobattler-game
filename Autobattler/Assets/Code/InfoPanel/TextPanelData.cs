using System;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
    public struct TextPanelData
    {
        public string title;
        [TextArea]
        public string content;

        public TextPanelData(string title, string content)
        {
            this.title = title;
            this.content = content;
        }
    }
}