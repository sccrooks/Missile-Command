using UnityEditor;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    [CustomEditor(typeof(AIEntity))]
    public class AIEntityEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            AIEntity aiEntity = (AIEntity)target;
            if (GUILayout.Button("Find new Target"))
                aiEntity?._aiLogicController.AIBrain.FindTarget();

            if (GUILayout.Button("Self Destruct"))
                aiEntity.Destroy();
        }
    }
}
