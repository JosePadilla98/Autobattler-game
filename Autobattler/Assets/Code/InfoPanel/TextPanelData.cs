using System;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
    public struct TextPanelData
    {
        public string title;
        [TextArea]
        [Space(10)]
        public string content;
        [Space(10)]
        public Sprite sprite;

        public TextPanelData(string title, string content, Sprite sprite)
        {
            this.title = title;
            this.content = content;
            this.sprite = sprite;
        }
    }
}