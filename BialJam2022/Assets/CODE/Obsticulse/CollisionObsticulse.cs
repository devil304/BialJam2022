using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObsticulse : MonoBehaviour
{
    public Action<Transform> onHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onHit.Invoke(other.transform);
        }
    }
}
