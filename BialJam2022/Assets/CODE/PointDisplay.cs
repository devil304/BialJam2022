using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
    [SerializeField] private bool isSecondPlayer;

    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private SecondRoundController controller;

    void Update()
    {
        text.text = isSecondPlayer? controller.Player2.ducks.ToString() : controller.Player1.ducks.ToString();
    }
}
