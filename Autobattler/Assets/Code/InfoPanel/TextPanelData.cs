using System;
using UnityEngine;

namespace Autobattler.InfoPanel
{
    [Serializable]
    public struct TextPanelData
    {
        public string title;
        public string content;
        public Sprite sprite;

        public TextPanelData(string title, string content, Sprite sprite)
        {
            this.title = title;
            this.content = content;
            this.sprite = sprite;
        }
    }
}