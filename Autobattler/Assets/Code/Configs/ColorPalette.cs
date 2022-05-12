using UnityEngine;

namespace Autobattler.Configs
{
    [CreateAssetMenu(fileName = "ColorsConfig", menuName = "ScriptableObjects/Config/PaletteColor", order = 1)]
    public class ColorPalette : ScriptableObject
    {
        public Color attack;
        public Color defense;

        [Header("Stats")] public Color health;

        public Color intellect;
        public Color magic;
        public Color magicDefense;
        public Color mana;
        public Color vigor;
    }
}