using UnityEngine;

namespace MissileCommand.Gameplay.Entities
{
    public class EntitySpawner : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private BoxCollider2D _spawnZone;

        public void InstantiateEntity(GameObject entity)
        {
            Instantiate(entity, GetRandomSpawnLocation(_spawnZone.bounds), Quaternion.identity, this.gameObject.transform);
        }

        private Vector3 GetRandomSpawnLocation(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                1
            );
        }
    }
}