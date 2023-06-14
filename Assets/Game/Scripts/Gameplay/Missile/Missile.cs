using MissileCommand.Gameplay.Enemies;
using MissileCommand.Infrastructure.ScriptableObjects;
using MissileCommand.Infrastructure.ScriptableObjects.Events;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float _reward;
    [SerializeField] private float _speed;
    [SerializeField] private GameObjectCollection _activeEntities;

    [Header("Events")]
    [SerializeField] private FloatGameEvent _missileDestroyed;

    public AIThinker AIThinker;

    private void Start()
    {
        _activeEntities.Add(this.gameObject);
    }

    public void MoveTowardsTarget(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    public void Destroy()
    {
        _activeEntities.Remove(this.gameObject);
        _missileDestroyed.Raise(_reward);
        Destroy(gameObject);
    }

    public void BaseCollision()
    {
        Debug.Log("Collided with Base");
        Destroy();
    }

    public void EnvironmentCollision()
    {
        Debug.Log("Collided with environment");
        Destroy();
    }
}
