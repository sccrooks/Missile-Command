using MissileCommand.Controls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 move = _controls.Reticle.Move.ReadValue<Vector2>();
        Debug.Log(move);

        if (_controls.Reticle.Fire.triggered)
            Debug.Log("Fired missile");
    }
}
