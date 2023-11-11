using AutobattlerOld.Grid.Logic;
using AutobattlerOld.Units.Combat;
using AutobattlerOld.Units.Combat.View;
using UnityEngine;

namespace AutobattlerOld.Grid.Views
{
    public class Slot_F_View : MonoBehaviour
    {
        public Slot_F logic;
        public Battefield_F_View battlefieldView;

        public Side Side => logic.GetSide();

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