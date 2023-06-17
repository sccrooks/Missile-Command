using MissileCommand.Gameplay;
using MissileCommand.Gameplay.Enemies;
using Sccrooks.Utility.ScriptableObjects.Events;
using Sccrooks.Utility.ScriptableObjects.RuntimeCollections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Entity
{
    [SerializeField] private float _reward;
    [SerializeField] private float _speed;

    [Header("Events")]
    [SerializeField] private FloatEvent _missileDestroyed;

    public AIThinker AIThinker;

    #region -- Start / OnDestroy --
    public override void Start()
    {
        base.Start();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        _missileDestroyed.Raise(_reward);
    }
    #endregion

    public override void Destroy()
    {
        base.Destroy();
    }

    public void MoveTowardsTarget(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    public void BaseCollision()
    {
        Destroy();
    }

    public void EnvironmentCollision()
    {
        Debug.Log("Collided with environment");
        Destroy();
    }
}
