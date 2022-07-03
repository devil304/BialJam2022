using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    [SerializeField] AudioManager _playerAudioManager;
    [SerializeField] AudioClip[] _bounceSFXes;

    public void SetAir(bool state)
    {
        anim.SetBool("inAir", state);
            
    }

    public void PlayBounce(){
        _playerAudioManager.PlaySFX(_bounceSFXes[Random.Range(0,_bounceSFXes.Length)],true);
    }

    public void SetWater(bool state)
    {
        anim.SetBool("inWater", state);
    }

    [ContextMenu("Lost Duck")]
    public void LostDuck()
    {
        anim.SetLayerWeight(1, 2);
        StartCoroutine(WaitToOff());
    }

    private IEnumerator WaitToOff()
    {
        yield return new WaitForSeconds(0.8f);
        anim.SetLayerWeight(1, 0);
    }
}
