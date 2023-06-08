using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void MoveTowardsTarget(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }


    public void BaseCollision()
    {
        Debug.Log("Collided with Base");
    }

    public void EnvironmentCollision()
    {
        Debug.Log("Collided with environment");
    }
}
