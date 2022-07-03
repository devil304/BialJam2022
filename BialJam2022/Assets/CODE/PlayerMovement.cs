using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public bool isSecondPlayer;
    [SerializeField] private float rollForce = 1f;
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float swimSpeed = 10f;
    [SerializeField] LayerMask _groundCheckMask;
    [SerializeField] private AnimationController anim;

    private EnviromentScaner _scaner;
    private InputGather _gather;
    private Rigidbody2D _rb;
    private SpriteRenderer _mySprite;
    private CircleCollider2D _collider;
    private bool _isGrounded,  _canStomp;
    
    

    public void SetMovement(MoveParametr parametr)
    {
        rollForce = parametr.rollForce;
        jumpForce = parametr.jumpForce;
        swimSpeed = parametr.swimSpeed;
    }

    private void Start()
    {
        _gather = GetComponent<InputGather>();
        _rb = GetComponent<Rigidbody2D>();
        _scaner = GetComponent<EnviromentScaner>();
        _mySprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();

        _gather.keys.jump += Jump;
    }

    private void Jump()
    {
        
        //Stomp
        // if(_canStomp && _gather.keys.movement.y < -0.5f && !_isGrounded)
        // {
        //     _rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        //     _canStomp = false;
        // }
        if (!_isGrounded || _scaner.CheckIsInWater()) return;
        //Jump
        if(_gather.keys.movement.y != 0 && _gather.keys.movement.y>0.36f)
        {
            _rb.AddForce(_gather.keys.movement.normalized * jumpForce, ForceMode2D.Impulse);
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
        if(!_mySprite.flipX && _rb.velocity.x<0 && Math.Abs(_rb.velocity.x)>0.064f)
            _mySprite.flipX = true;
        else if(_mySprite.flipX && _rb.velocity.x>0 && Math.Abs(_rb.velocity.x)>0.064f)
            _mySprite.flipX = false;
    }

    private void PerformInWaterAction()
    {
        if (_scaner.CheckIsInAir()) return;
        _rb.gravityScale = 0.43f;
        //free Move
        if (_gather.keys.movement.sqrMagnitude > 0.01f)
        {   
            _rb.velocity = (_gather.keys.movement.normalized * swimSpeed * Time.fixedDeltaTime);
            //_rb.AddForce(_gather.keys.movement * swimSpeed * Time.deltaTime);
        }

    }

    private void PerformInAirAction()
    {
        if (_scaner.CheckIsInWater()) return;
        _rb.gravityScale = 1.5f;
        //roll
        if (_gather.keys.movement.sqrMagnitude > 0.01f)
        {
            //Debug.Log(_gather.keys.movement * rollForce);
            _rb.AddForceAtPosition(_gather.keys.movement.normalized * (_isGrounded? rollForce : rollForce * 0.5f) * Time.deltaTime, transform.position + (Vector3)(Vector2.up * 0.1f));
        }

        //ground chek
        _isGrounded = Physics2D.BoxCast(transform.position, Vector3.up*0.6f+Vector3.right*1.2f, 0, Vector2.down, 1.15f * _collider.radius, _groundCheckMask);
        _canStomp = !_isGrounded;
        anim.SetAir(!_isGrounded);
    }

    void OnDrawGizmosSelected()
    {
        if(!_collider)
            _collider = GetComponent<CircleCollider2D>();
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position+Vector3.down*1.15f * _collider.radius,Vector3.up*0.6f+Vector3.right*1.2f);
    }
}

[System.Serializable]
public struct MoveParametr
{
    public float rollForce;
    public float jumpForce;
    public float swimSpeed;
}
