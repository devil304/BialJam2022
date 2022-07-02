using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-50)]
public class Points : MonoBehaviour
{
    public static Points instance;
    public int player1Point;
    public int player2Point;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void IncreasePlayer1Points() => player1Point++;
    public void IncreasePlayer2Points() => player2Point++;
}
