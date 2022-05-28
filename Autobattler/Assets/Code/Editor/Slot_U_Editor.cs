using System;
using Autobattler.Grid.Logic;
using Autobattler.ScriptableCollections;
using Autobattler.Units;
using UnityEditor;
using UnityEngine;

namespace Autobattler
{
    [CustomEditor(typeof(Slot_U), editorForChildClasses: true)]
    public class Slot_U_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            Slot_U slot = target as Slot_U;

            _Unit unitContained = slot.myItem;
            if (unitContained != null)
            {
                EditorGUILayout.LabelField(unitContained.name);
            }
        }


        public override bool RequiresConstantRepaint()
        {
            return true;
        }
    }
}
