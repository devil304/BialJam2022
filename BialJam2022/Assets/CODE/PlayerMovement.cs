using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rollForce = 1f;
    [SerializeField] private float jumpForce = 100f;

    private InputGather _gather;
    private Rigidbody2D _rb;

    private void Start()
    {
        _gather = GetComponent<InputGather>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(_gather.InputKey.movement.sqrMagnitude > 0.01f)
        {
            Debug.Log(_gather.InputKey.movement * rollForce);
            _rb.AddForceAtPosition(_gather.InputKey.movement * rollForce * Time.deltaTime, transform.position + (Vector3)(Vector2.up * 0.1f));
        }

        if(_gather.InputKey.jumpButton && _gather.InputKey.movement.y != 0)
        {
            _rb.AddForce(_gather.InputKey.movement * jumpForce, ForceMode2D.Impulse);
        }
    }
}
