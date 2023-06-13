using MissileCommand.Infrastructure.ScriptableObjects;
using MissileCommand.Infrastructure.ScriptableObjects.Events;
using QFSW.QC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private  GameObjectCollection _entityCollection;

    [Command("Spawn-Missile")]
    public void SpawnMissileCmd()
    {
        _entityCollection.Items.Add(_missilePrefab);
    }
}
