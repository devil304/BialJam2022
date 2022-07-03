using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;

    void OnEnable()
    {
        if(Points.instance.player1Point > Points.instance.player2Point)
        {
            text.text = "Winner is Player 1";
        }   
        else if(Points.instance.player1Point < Points.instance.player2Point)
        {
            text.text = "Winner is Player 2";
        }
        else
        {
            text.text = "No one win";
        }
    }
}
