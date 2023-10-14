using Sccrooks.Utility.ScriptableObjects.Variables;
using TMPro;
using UnityEngine;

namespace MissileCommand.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private IntVariable _score;

        private void OnValidate()
        {
            _tmpText = GetComponent<TMP_Text>();
        }

        // Start is called before the first frame update
        void Start()
        {
            _tmpText.text = $"SCORE: {_score.RuntimeValue.ToString()}";
        }
    }
}
