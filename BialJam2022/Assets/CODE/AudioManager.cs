using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] _SFXLoopSources;
    [SerializeField] AudioSource[] _SFXSources;


    public void PlaySFX(AudioClip clip){
        var sfxSource = _SFXSources.FirstOrDefault(sfx=>!sfx.isPlaying);
        if(sfxSource==default(AudioSource)){
            Debug.LogWarning("Not enaugh SFX audio sources");
            return;
        }
        sfxSource.PlayOneShot(clip);
    }

    public int PlaySFXLoop(AudioClip clip){
        var sfxLoopSource = _SFXLoopSources.FirstOrDefault(sfx=>!sfx.isPlaying);
        if(sfxLoopSource==default(AudioSource)){
            Debug.LogWarning("Not enaugh SFX Loop audio sources");
            return -1;
        }
        sfxLoopSource.clip=clip;
        sfxLoopSource.Play();
        return _SFXLoopSources.ToList().IndexOf(sfxLoopSource);
    }

    public void StopSFXLoop(int index){
        _SFXLoopSources[index].Stop();
    }
}
