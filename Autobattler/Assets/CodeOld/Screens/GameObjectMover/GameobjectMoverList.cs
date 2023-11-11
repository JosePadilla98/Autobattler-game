using UnityEngine;

namespace AutobattlerOld.Screens.GameObjectMover
{
    public class GameobjectMoverList : MonoBehaviour
    {
        public GameobjectMover[] list;

        private void Awake()
        {
            foreach (var mover in list)
            {
                mover.Init();
            }
        }

        public void EnableState1()
        {
            foreach (var mover in list)
            {
                mover.EnableState1();
            }
        }

        public void EnableState2()
        {
            foreach (var mover in list)
            {
                mover.EnableState2();
            }
        }
    }
}
