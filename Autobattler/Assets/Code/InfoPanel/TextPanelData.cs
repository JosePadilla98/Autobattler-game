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
    }
}