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

    [SerializeField] private float winerCollisionRadius;
    [SerializeField] private float loserCollisionRadius;
    

    public PlayerInfo Player1 => player1;
    public PlayerInfo Player2 => player2;

    [ContextMenu("Point to Player 1")]
    public void AddPointToPlayer1()
    {
        player1.ducks++;
        CheckWineLoser();
    }

    [ContextMenu("Point to Player 2")]
    public void AddPointToPlayer2()
    {
        player2.ducks++;
        CheckWineLoser();
    }

    void Start()
    {
        CheckWineLoser();
    }

    private void CheckWineLoser()
    {
        if(player1.ducks == player2.ducks) return;
        if(player1.ducks > player2.ducks)
        {
            SetWiner(player1);
            SetLoser(player2);
        }
        else
        {
            SetWiner(player2);
            SetLoser(player1);
        }
    }

    private void SetLoser(PlayerInfo player)
    {
        player.sprite.sprite = loserSprite;
        player.movement.SetMovement(loser);
        player.collider.radius = loserCollisionRadius;
    }

    private void SetWiner(PlayerInfo player)
    {
        player.sprite.sprite = winerSprite;
        player.movement.SetMovement(winer);
        player.collider.radius = winerCollisionRadius;
    }
}

[Serializable]
public class PlayerInfo
{
    public int ducks;
    public SpriteRenderer sprite;
    public PlayerMovement movement;
    public CircleCollider2D collider;
}
