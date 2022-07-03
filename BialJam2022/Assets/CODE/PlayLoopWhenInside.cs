using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLoopWhenInside : MonoBehaviour
{
    [SerializeField] AudioClip _sfxLoopClip;
    [SerializeField] float _minDist, _maxDist;
    [SerializeField] bool _louder = true;
    AudioManager _audioManager;
    
    int _sfxId = -1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        if(!_audioManager)
            _audioManager = other.GetComponent<Follow>().AudioManager;
        if(_sfxId>0) return;
        _sfxId = _audioManager.PlaySFXLoop(_sfxLoopClip,false,_louder);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        if(_sfxId<0) return;
        _audioManager.StopSFXLoop(_sfxId);
        _sfxId=-1;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        if(_sfxId<0) return;
        _audioManager.ControllSFXLoopVol(_sfxId,Mathf.Clamp01(1f-((other.transform.position-transform.position).magnitude)/(_maxDist-_minDist)));
    }
}
