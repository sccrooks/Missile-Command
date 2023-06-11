using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    [CustomEditor(typeof(Missile))]
    public class MissleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Missile brain = (Missile)target;
            if (GUILayout.Button("Find new Target"))
                brain?.AIThinker.Brain.FindTarget();
        }
    }
}
