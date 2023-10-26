using System;
using AutobattlerOld.ScriptableCollections;
using AutobattlerOld.Units;
using AutobattlerOld.Units.Management;
using UnityEditor;
using UnityEngine;

namespace AutobattlerOld
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
