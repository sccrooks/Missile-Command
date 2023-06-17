using Sccrooks.Utility.ScriptableObjects.Variables;
using UnityEngine;

namespace MissileCommand.Gameplay.Reticle
{
    public class ReticleController : MonoBehaviour
    {
        public Transform Transform => this.transform;
        [SerializeField] private GameObjectVariable _reticleVariable;

        private void Start()
        {
            _reticleVariable.RunTimeValue = this.gameObject;
        }
    }
}
