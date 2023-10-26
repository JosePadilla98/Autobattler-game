using AutobattlerOld.MutationsSystem.Mutations;
using UnityEngine;
using UnityEngine.UI;

namespace AutobattlerOld.MutationsSystem
{
    public class MutationView : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public Mutation mutation;

        public void InyectDependences(Mutation mutation)
        {
            this.mutation = mutation;
            image.sprite = mutation.Model.sprite;
        }
    }
}