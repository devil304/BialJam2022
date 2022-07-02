using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
    [SerializeField] private bool isSecondPlayer;

    [SerializeField] private TMPro.TextMeshProUGUI text;

    void Update()
    {
        text.text = isSecondPlayer? Points.instance.player2Point.ToString() : Points.instance.player1Point.ToString();
    }
}
