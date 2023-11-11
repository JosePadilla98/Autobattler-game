using AutobattlerOld.ScriptableCollections;
using UnityEditor;
using UnityEngine;

namespace AutobattlerOld
{
    [CustomEditor(typeof(ItemsCollection), editorForChildClasses: true)]
    public class ItemsCollectionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            ItemsCollection items = target as ItemsCollection;

            ShowItems(items);
        }

        private void ShowItems(ItemsCollection items)
        {
            foreach (var item in items.Collection)
            {
                EditorGUILayout.LabelField(item.Scriptable.name);
            }
        }

        public override bool RequiresConstantRepaint()
        {
            return true;
        }
    }
}
