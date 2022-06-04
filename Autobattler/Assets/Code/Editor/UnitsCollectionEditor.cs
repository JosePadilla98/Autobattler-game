using System;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using Autobattler.Units.Management;
using UnityEditor;
using UnityEngine;

namespace Autobattler
{
    [CustomEditor(typeof(UnitsCollection), editorForChildClasses: true)]
    public class UnitsCollectionEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            UnitsCollection e = target as UnitsCollection;

            ShowUnits(e);
        }

        private void ShowUnits(UnitsCollection e)
        {
            foreach (Unit unit in e.Collection)
            {
                EditorGUILayout.LabelField(unit.name);
            }
        }

        public override bool RequiresConstantRepaint()
        {
            return true;
        }
    }
}
