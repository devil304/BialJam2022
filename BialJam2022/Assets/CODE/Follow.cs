using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Follow : MonoBehaviour
{
    List<Vector2> posHistory = new List<Vector2>();

    List<Transform> _chickens = new List<Transform>();
    List<SpriteRenderer> _chickenSprites = new List<SpriteRenderer>();
    PlayerMovement _myPlayerM;

    Tween _goToEndTween;

    [SerializeField] AudioManager _playerAudioManager;
    [SerializeField] AudioClip[] _gotChickenSFXes;
    [SerializeField] AudioClip[] _lostChickenSFXes;

    void Awake()
    {
        _myPlayerM = GetComponent<PlayerMovement>();
    }

    public void AddChicken(Transform chicken){
        if(!chicken) return;
        _playerAudioManager.PlaySFX(_gotChickenSFXes[Random.Range(0,_gotChickenSFXes.Length)]);
        var pos = Vector2.zero;
        int i = _chickens.Count;
            if(i==0){
                pos = posHistory[posHistory.Count-6];
            }else{
                pos = posHistory[posHistory.Count-6-(i*4)];
            }
        _goToEndTween = chicken.DOMove(pos,0.1f).OnComplete(()=>{_chickens.Add(chicken);_chickenSprites.Add(chicken.GetComponent<SpriteRenderer>());});
    }

    public void RemoveChickens(int count){
        _playerAudioManager.PlaySFX(_lostChickenSFXes[Random.Range(0,_lostChickenSFXes.Length)]);
        if(_chickens.Count == 0) return;
        if(_chickens.Count < count)
        {
            for (var i = 0; i < _chickens.Count; i++)
            {
                _chickens[i].DOMove(_chickens[i].position+Vector3.down*25f,1.5f);
                if (_myPlayerM.isSecondPlayer)
                    Points.instance.player2Point--;
                else
                    Points.instance.player1Point--;
            }
            _chickens.Clear();
            _chickenSprites.Clear();
            return;
        }
        for (var i = _chickens.Count-count; i < _chickens.Count; i++)
        {
            _chickens[i].DOMove(_chickens[i].position+Vector3.down*25f,1.5f);
            if (_myPlayerM.isSecondPlayer)
                Points.instance.player2Point--;
            else
                Points.instance.player1Point--;
        }
        _chickenSprites.RemoveRange(_chickens.Count-count,count);
        _chickens.RemoveRange(_chickens.Count-count,count);
    }

    public Transform StealChicken(){
        if(_chickens.Count==0)
            return null;
        _chickenSprites.RemoveAt(_chickens.Count-1);
        var chicken = _chickens.Last();
        _chickens.RemoveAt(_chickens.Count-1);
        return chicken;
    }

    [SerializeField] float _maxMag = 0;

    void Update()
    {
        var mag = posHistory.Count>0?(((Vector2)transform.position)-posHistory.Last()).magnitude:0;
        if(posHistory.Count==0 || mag > 0.25f){
            if(mag>=0.5f && posHistory.Count>0){
                for(float i=0.25f;i<mag;i+=0.25f)
                    posHistory.Add(posHistory.Last()+(((Vector2)transform.position-posHistory.Last()).normalized*0.25f));
            }else
                posHistory.Add(posHistory.Count>0?posHistory.Last()+(((Vector2)transform.position-posHistory.Last()).normalized*0.25f):transform.position);
            if(_goToEndTween!=null && _goToEndTween.active)
                _goToEndTween.Complete();
        }
        if(mag>_maxMag)
            _maxMag = mag;
        if(posHistory.Count>(6+(_chickens.Count+1)* 4))
            posHistory.RemoveRange(0,posHistory.Count%(6+(_chickens.Count+1)* 4));

        if(posHistory.Count<(8+_chickens.Count*4)) return;

        for(int i=0;i<_chickens.Count;i++){
            var pos = Vector2.zero;
            if(i==0){
                pos = Vector2.Lerp(posHistory[posHistory.Count-6],posHistory[posHistory.Count-5],(mag%0.25f)/0.25f);
            }else{
                pos = Vector2.Lerp(posHistory[posHistory.Count-6-(i*4)],posHistory[posHistory.Count-5-(i*4)],(mag%0.25f)/0.25f);
            }
            if(!_chickenSprites[i].flipX && pos.x<_chickens[i].position.x && Math.Abs(pos.x-_chickens[i].position.x)>0.01f)
                _chickenSprites[i].flipX = true;
            else if(_chickenSprites[i].flipX && pos.x>_chickens[i].position.x && Math.Abs(pos.x-_chickens[i].position.x)>0.01f)
                _chickenSprites[i].flipX = false;
            _chickens[i].position = pos;
        }
    }
}
