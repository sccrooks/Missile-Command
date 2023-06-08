using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public void BaseCollision()
    {
        Debug.Log("Collided with Base");
    }

    public void EnvironmentCollision()
    {
        Debug.Log("Collided with environment");
    }
}
