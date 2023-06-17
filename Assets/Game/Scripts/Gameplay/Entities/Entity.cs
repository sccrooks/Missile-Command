using Sccrooks.Utility.ScriptableObjects.RuntimeCollections;
using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class Entity : MonoBehaviour
    {
        [Header("Collections")]
        [SerializeField] private GameObjectCollection _activeEntities;

        #region -- Start / OnDestroy --
        public virtual void Start()
        {
            _activeEntities.Add(this.gameObject);
        }

        public virtual void OnDestroy()
        {
            _activeEntities.Remove(this.gameObject);
        }
        #endregion

        public virtual void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
