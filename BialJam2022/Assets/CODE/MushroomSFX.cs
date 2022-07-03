using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSFX : MonoBehaviour
{
    [SerializeField] AudioClip _sfxClip;

    AudioManager _audioManager;

    bool _sfxPlayed=false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Player") || _sfxPlayed || other.transform.position.y<=(transform.position.y+0.5f)) return;
        if(!_audioManager)
            _audioManager = other.gameObject.GetComponent<Follow>().AudioManager;
        _audioManager.PlaySFX(_sfxClip);
        _sfxPlayed=true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag("Player")) return;
        _sfxPlayed = false;
    }
}
