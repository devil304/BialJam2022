using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] _SFXLoopSources;
    [SerializeField] AudioSource[] _SFXSources;

    Dictionary<AudioSource,float> ASBaseVol = new Dictionary<AudioSource, float>();
    
    float _baseVol;

    void Awake()
    {
        _baseVol = _SFXSources[0].volume;
        foreach(var AS in _SFXLoopSources)
            ASBaseVol.Add(AS,AS.volume);
    }

    public void PlaySFX(AudioClip clip, bool quiter=false){
        var sfxSource = _SFXSources.FirstOrDefault(sfx=>!sfx.isPlaying);
        if(sfxSource==default(AudioSource)){
            Debug.LogWarning("Not enaugh SFX audio sources");
            return;
        }
        if(quiter)
            sfxSource.volume = _baseVol*0.2f;
        else
            sfxSource.volume = _baseVol;
        sfxSource.PlayOneShot(clip);
    }

    public int PlaySFXLoop(AudioClip clip, bool quiter=false, bool louder = false){
        var sfxLoopSource = _SFXLoopSources.FirstOrDefault(sfx=>!sfx.isPlaying);
        if(sfxLoopSource==default(AudioSource)){
            Debug.LogWarning("Not enaugh SFX Loop audio sources");
            return -1;
        }
        if(quiter)
            sfxLoopSource.volume = _baseVol*0.2f;
        else if(louder)
            sfxLoopSource.volume = _baseVol*2f;
        else
            sfxLoopSource.volume = _baseVol;
        ASBaseVol[sfxLoopSource] = sfxLoopSource.volume;
        sfxLoopSource.clip=clip;
        sfxLoopSource.Play();
        return _SFXLoopSources.ToList().IndexOf(sfxLoopSource);
    }

    public void StopSFXLoop(int index){
        _SFXLoopSources[index].Stop();
    }

    public void ControllSFXLoopVol(int index,float vol){
        _SFXLoopSources[index].volume = ASBaseVol[_SFXLoopSources[index]]*vol;
    }
}
