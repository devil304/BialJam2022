using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BeeDuck : MonoBehaviour
{
    [SerializeField] private bool isMoving = true;
    [SerializeField] private float speed;
    [SerializeField] private Transform ULPoint;
    [SerializeField] private Transform DRPoint;
    [SerializeField] private CollisionObsticulse collision;

    [SerializeField] private AudioManager audio;

    [SerializeField] private AudioClip[] clips;

    private Vector2 _randomDestination;
    private List<Vector2> _posHis;
    Tween _tween;

    void Start()
    {
        if(isMoving)_randomDestination = GetRandomPosition();
        _posHis = new List<Vector2>();
        collision.onHit += HitPlayer;
        WorldManager.ChunkUpdate += WorldUpdated;
    }

    private void WorldUpdated()
    {
        if((collision.transform.position-transform.position).sqrMagnitude>100f*100f){
            if(_tween.active)
                _tween.Kill();
            collision.transform.position = transform.position;
        }
    }

    void Update()
    {
        if(!isMoving) return;
        var dist = Vector2.Distance(_randomDestination,collision.transform.position);
        if(dist>100f) return;
        if(dist > 0.25f)
        {
            _tween = collision.transform.DOMove(_randomDestination, speed);
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
