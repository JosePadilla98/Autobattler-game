using Autobattler.Player;
using Autobattler.Units;
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
            if (e.collection == null)
                return;
                
            foreach (Unit unit in e.collection)
            {
                EditorGUILayout.LabelField(unit.name);
            }
        }
    }
}
