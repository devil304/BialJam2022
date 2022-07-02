using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private List<Vector2> _velocityHis;
    private Rigidbody2D _rb;
    private Follow _myFollow;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            var dot1 = Vector2.Dot(_velocityHis[0].normalized,((Vector2)(collision.transform.position-transform.position)).normalized);
            var dot2 = Vector2.Dot(_velocityHis[1].normalized,((Vector2)(collision.transform.position-transform.position)).normalized);
            Debug.Log($"Dot1: {dot1}, Dot2: {dot2}");
            if(dot1>0.75f || dot2>0.75f){
                _myFollow.AddChicken(collision.gameObject.GetComponent<Follow>().StealChicken());
            }
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _myFollow = GetComponent<Follow>();
        _velocityHis = new List<Vector2>();
    }

    void Update()
    {
        RegistrVelocity();
    }

    private void RegistrVelocity()
    {
        _velocityHis.Add(_rb.velocity);
        if(_velocityHis.Count >= 3) _velocityHis.RemoveAt(0);
    }
}
