using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SecondRoundController : MonoBehaviour
{
    public static SecondRoundController instance;

    [SerializeField] private Spawner spawner;

    [SerializeField] private PlayerInfo player1;
    [SerializeField] private PlayerInfo player2;

    [SerializeField] private MoveParametr winer;
    [SerializeField] private MoveParametr loser;

    [SerializeField] private Sprite winerSprite;
    [SerializeField] private Sprite loserSprite;

    [SerializeField] private float winerCollisionRadius;
    [SerializeField] private float loserCollisionRadius;

    [SerializeField] private AnimatorController winnerController;
    [SerializeField] private AnimatorController loserController;

    public PlayerInfo Player1 => player1;
    public PlayerInfo Player2 => player2;

    void Awake()
    {
        instance = this;
    }

    public void AddPointToPlayer1(GameObject duck)
    {
        Points.instance.IncreasePlayer1Points();
        CheckWineLoser();
        spawner.RemoveDuck(duck);
    }

    public void AddPointToPlayer2(GameObject duck)
    {
        Points.instance.IncreasePlayer2Points();
        CheckWineLoser();
        spawner.RemoveDuck(duck);
    }

    void Start()
    {
        CheckWineLoser();
    }

    private void CheckWineLoser()
    {
        if(Points.instance.player2Point == Points.instance.player1Point) return;
        if(Points.instance.player1Point > Points.instance.player2Point)
        {
            SetWiner(player1);
            SetLoser(player2);
        }
        else
        {
            SetWiner(player2);
            SetLoser(player1);
        }
        if (Points.instance.player1Point >= 10 || Points.instance.player2Point >= 10) GameEnd();
    }

    private static void GameEnd()
    {
        Time.timeScale = 0;
    }

    private void SetLoser(PlayerInfo player)
    {
        player.sprite.sprite = loserSprite;
        player.movement.SetMovement(loser);
        player.collider.radius = loserCollisionRadius;
        player.anim.runtimeAnimatorController = loserController;
    }

    private void SetWiner(PlayerInfo player)
    {
        player.sprite.sprite = winerSprite;
        player.movement.SetMovement(winer);
        player.collider.radius = winerCollisionRadius;
        player.anim.runtimeAnimatorController = winnerController;
    }
}

[Serializable]
public class PlayerInfo
{
    public SpriteRenderer sprite;
    public PlayerMovement movement;
    public CircleCollider2D collider;
    public Animator anim;
}
