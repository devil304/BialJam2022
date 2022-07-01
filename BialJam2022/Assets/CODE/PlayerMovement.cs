using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rollForce = 1f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] LayerMask _groundCheckMask;

    private InputGather _gather;
    private Rigidbody2D _rb;
    bool _isGrounded, _inWater;

    private void Start()
    {
        _gather = GetComponent<InputGather>();
        _rb = GetComponent<Rigidbody2D>();
        _gather.keys.jump += Jump;
    }

    private void Jump()
    {
        if(_gather.keys.movement.y != 0 && (_inWater||_isGrounded||_gather.keys.movement.y<0.5f))
        {
            _rb.AddForce(_gather.keys.movement * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        if(_gather.keys.movement.sqrMagnitude > 0.01f)
        {
            Debug.Log(_gather.keys.movement * rollForce);
            _rb.AddForceAtPosition(_gather.keys.movement * rollForce * Time.deltaTime, transform.position + (_inWater?Vector3.zero:(Vector3)(Vector2.up * 0.1f)));
        }

        if(!_inWater)
            _isGrounded = Physics2D.BoxCast(transform.position,Vector2.one*0.5f,0,Vector2.down,0.3f,_groundCheckMask);

        /* if(_gather.keys.jumpButton && _gather.keys.movement.y != 0)
        {
            _rb.AddForce(_gather.keys.movement * jumpForce, ForceMode2D.Impulse);
        } */
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position+Vector3.down*0.3f,Vector3.one*0.5f);
    }
}
