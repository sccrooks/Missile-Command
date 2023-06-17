using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Enemies
{
    [CustomEditor(typeof(AIEntity))]
    public class MissleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AIEntity missile = (AIEntity)target;
            if (GUILayout.Button("Find new Target"))
                missile?.AIThinker.Brain.FindTarget();

            if (GUILayout.Button("Self Destruct"))
                missile.Destroy();
        }
    }
}
