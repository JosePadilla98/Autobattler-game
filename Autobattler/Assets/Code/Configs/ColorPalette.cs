using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auttobattler
{
    [CreateAssetMenu(fileName = "ColorsConfig", menuName = "ScriptableObjects/Config/PaletteColor", order = 1)]
    public class ColorPalette : ScriptableObject
    {
        [Header("Stats")]
        public Color health;
        public Color attack;
        public Color defense;
        public Color magic;
        public Color magicDefense;
        public Color ult;
        public Color mana;
        public Color cdr;
        public Color vigor;
    }
}
