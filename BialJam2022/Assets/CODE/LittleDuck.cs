using System.Globalization;
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
            AddPoint(other);
        }
    }

    private void AddPoint(Collider2D other)
    {
        if (SecondRoundController.instance != null)
        {
            if (other.GetComponent<PlayerMovement>().isSecondPlayer)
                SecondRoundController.instance.AddPointToPlayer2(gameObject);
            else
                SecondRoundController.instance.AddPointToPlayer1(gameObject);
        }
        else
        {
            if (other.GetComponent<PlayerMovement>().isSecondPlayer)
                Points.instance.player2Point++;
            else
                Points.instance.player1Point++;
        }
    }
}
