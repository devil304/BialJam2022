using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoundController : MonoBehaviour
{
    [SerializeField] private PlayerInfo player1;
    [SerializeField] private PlayerInfo player2;

    [SerializeField] private MoveParametr winer;
    [SerializeField] private MoveParametr loser;

    [SerializeField] private Sprite winerSprite;
    [SerializeField] private Sprite loserSprite;
    

    void Start()
    {
        if(player1.ducks > player2.ducks)
        {
            player1.sprite.sprite = winerSprite;
            player1.movement.SetMovement(winer);

            player2.sprite.sprite = loserSprite;
            player2.movement.SetMovement(loser);
        }
        else
        {
            player2.sprite.sprite = winerSprite;
            player2.movement.SetMovement(winer);

            player1.sprite.sprite = loserSprite;
            player1.movement.SetMovement(loser);
        }
    }
}

[Serializable]
public class PlayerInfo
{
    public int ducks;
    public SpriteRenderer sprite;
    public PlayerMovement movement;
}
