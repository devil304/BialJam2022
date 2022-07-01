using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rollForce = 1f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float swimSpeed = 10f;
    [SerializeField] LayerMask _groundCheckMask;

    private EnviromentScaner _scaner;
    private InputGather _gather;
    private Rigidbody2D _rb;
    private bool _isGrounded,  _canStomp;

    private void Start()
    {
        _gather = GetComponent<InputGather>();
        _rb = GetComponent<Rigidbody2D>();
        _scaner = GetComponent<EnviromentScaner>();

        _gather.keys.jump += Jump;
    }

    private void Jump()
    {
        
        //Stomp
        if(_canStomp && _gather.keys.movement.y < -0.5f && !_isGrounded)
        {
            _rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
            _canStomp = false;
        }
        if (!_isGrounded || _scaner.CheckIsInWater()) return;
        //Jump
        if(_gather.keys.movement.y != 0 && _gather.keys.movement.y>0.36f)
        {
            _rb.AddForce(_gather.keys.movement * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        
        PerformInAirAction();

        //PerformInWaterAction();

    }

    void FixedUpdate()
    {
        PerformInWaterAction();
    }

    private void PerformInWaterAction()
    {
        if (_scaner.CheckIsInAir()) return;
        _rb.gravityScale = 0.43f;
        //free Move
        if (_gather.keys.movement.sqrMagnitude > 0.01f)
        {   
            _rb.velocity = (_gather.keys.movement * swimSpeed * Time.fixedDeltaTime);
            //_rb.AddForce(_gather.keys.movement * swimSpeed * Time.deltaTime);
        }

    }

    private void PerformInAirAction()
    {
        if (_scaner.CheckIsInWater()) return;
        _rb.gravityScale = 1f;
        //roll
        if (_gather.keys.movement.sqrMagnitude > 0.01f)
        {
            //Debug.Log(_gather.keys.movement * rollForce);
            _rb.AddForceAtPosition(_gather.keys.movement * rollForce * Time.deltaTime, transform.position + (Vector3)(Vector2.up * 0.1f));
        }

        //ground chek
        _isGrounded = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0, Vector2.down, 0.4f, _groundCheckMask);
        _canStomp = !_isGrounded;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position+Vector3.down*0.4f,Vector3.one*0.5f);
    }
}
