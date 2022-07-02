using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private List<Vector2> _velocityHis;
    private Rigidbody2D _rb;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //if(Vector2.Dot(_velocityHis[0], _velocityHis[1]))
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _velocityHis = new List<Vector2>();
    }

    void Update()
    {
        RegistrVelocity();
    }

    private void RegistrVelocity()
    {
        if(_velocityHis.Count >= 2) _velocityHis.RemoveAt(0);
        _velocityHis.Add(_rb.velocity);
    }
}
