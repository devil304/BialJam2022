using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BeeDuck : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform ULPoint;
    [SerializeField] private Transform DRPoint;
    [SerializeField] private CollisionObsticulse collision;

    private Vector2 _randomDestination;
    private List<Vector2> _posHis;

    void Start()
    {
        _randomDestination = GetRandomPosition();
        _posHis = new List<Vector2>();
        collision.onHit += HitPlayer;
    }

    void Update()
    {
        if(Vector2.Distance(_randomDestination,collision.transform.position) > 0.25f)
        {
            collision.transform.DOMove(_randomDestination, speed);
        }
        else
        {
            _randomDestination = GetRandomPosition();
        }
        RegisterMove();
        FlipSprite();
    }

    private void HitPlayer(Transform player)
    {
        player.GetComponent<Follow>().RemoveChickens(2);
        player.GetComponent<AnimationController>().LostDuck();
    }

    private Vector2 GetRandomPosition()
    {
        return new Vector2(UnityEngine.Random.Range(ULPoint.position.x, DRPoint.position.x), UnityEngine.Random.Range(DRPoint.position.y, ULPoint.position.y) );
    }

    private void RegisterMove()
    {
        _posHis.Add(collision.transform.position);
        if(_posHis.Count >= 3) _posHis.RemoveAt(0);
    }

    private void FlipSprite()
    {
        if(_posHis.Count < 2) return;
        Debug.Log((_posHis[0] - _posHis[1]).x);
        if((_posHis[0] - _posHis[1]).x > 0)
        {
            collision.transform.localScale = Vector3.one;
        }
        else
        {
            collision.transform.localScale = new Vector3(-1,1,1);
        }
    }
}