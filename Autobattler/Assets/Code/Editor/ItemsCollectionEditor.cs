using System;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEditor;
using UnityEngine;

namespace Autobattler
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
