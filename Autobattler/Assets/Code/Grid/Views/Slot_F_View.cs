using Autobattler.Grid.Logic;
using Autobattler.Units;
using Autobattler.Units.Combat;
using Autobattler.Units.Combat.View;
using UnityEngine;

namespace Autobattler.Grid.Views
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