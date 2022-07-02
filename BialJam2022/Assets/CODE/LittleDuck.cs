using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDuck : MonoBehaviour
{
    private bool _collected;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player") && !_collected)
        {
            UnityEngine.Debug.Log("Collected");
            _collected = true;
            other.GetComponent<Follow>().AddChicken(transform);
        }
    }
}
