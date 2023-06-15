using QFSW.QC;
using Sccrooks.Utility.ScriptableObjects.RuntimeCollections;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private GameObjectCollection _entityCollection;

    [Command("Spawn-Missile")]
    public void SpawnMissileCmd()
    {
        GameObject entity = _missilePrefab;
        _entityCollection.Add(entity);
    }
}
