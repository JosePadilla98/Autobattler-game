using Autobattler.Units;
using UnityEngine;

namespace Autobattler.Grid.CombatState
{
    public class Slot_F_View : MonoBehaviour
    {
        public Slot_F logic;
        public Battefield_F_View battlefieldView;

        public Side Side
        {
            get => logic.GetSide();
        }

        public FighterView fighterViewPrefab => battlefieldView.fighterViewPrefab;

        private void Awake()
        {
            logic.OnNewItemBuilded += BuildFighterView;
        }

        private void BuildFighterView(Fighter fighter)
        {
            FighterView fighterView = Instantiate(PrefabToInstantiate(), transform);
            fighterView.InyectDependences(fighter);

            if (Side == Side.RIGHT)
            {
                fighterView.image.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        private FighterView PrefabToInstantiate()
        {
            return fighterViewPrefab;
        }
    }
}