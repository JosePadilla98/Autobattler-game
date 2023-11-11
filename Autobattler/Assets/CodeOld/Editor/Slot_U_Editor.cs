using AutobattlerOld.Grid.Logic;
using AutobattlerOld.Units.Management;
using UnityEditor;
using UnityEngine;

namespace AutobattlerOld
{
    [CustomEditor(typeof(Slot_U), editorForChildClasses: true)]
    public class Slot_U_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            Slot_U slot = target as Slot_U;

            Unit unitContained = slot.myItem;
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
