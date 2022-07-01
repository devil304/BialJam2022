using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGather : MonoBehaviour
{

    private InputKey keys;

    public InputKey InputKey => keys;

    private void Start()
    {
        keys = new InputKey();
    }

    void Update()
    {
        keys.movement = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        keys.jumpButton = Input.GetKeyDown(KeyCode.Space);
    }
}

public struct InputKey
{
    public Vector2 movement;
    public bool jumpButton;
}
