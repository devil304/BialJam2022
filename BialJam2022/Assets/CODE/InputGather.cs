using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputGather : MonoBehaviour
{

    public InputKey keys;

    PlayerInputBaseMap _myMap;

    private void Awake()
    {
        keys = new InputKey();
    }

    void Update()
    {
        
    }

    public void RegisterMap(PlayerInputBaseMap map){
        _myMap = map;
        _myMap.Movement.Roll.performed += RollPerformed;
        _myMap.Movement.Roll.canceled += RollEnded;
        _myMap.Movement.ApplyForce.started += JumpStarted;
    }

    private void JumpStarted(InputAction.CallbackContext obj)
    {
        if(obj.ReadValueAsButton())
            keys.jump?.Invoke();
    }

    private void RollEnded(InputAction.CallbackContext obj)
    {
        keys.movement = Vector2.zero;
    }

    private void RollPerformed(InputAction.CallbackContext obj)
    {
        keys.movement = obj.ReadValue<Vector2>();
    }
}

public struct InputKey
{
    public Vector2 movement;
    public Action jump;
}
