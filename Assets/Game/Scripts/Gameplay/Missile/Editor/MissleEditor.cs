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

            Missile missile = (Missile)target;
            if (GUILayout.Button("Find new Target"))
                missile?.AIThinker.Brain.FindTarget();

            if (GUILayout.Button("Self Destruct"))
                missile.Destroy();
        }
    }
}
