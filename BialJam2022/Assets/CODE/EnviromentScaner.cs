using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentScaner : MonoBehaviour
{
    [SerializeField] private AnimationController anim;
    [SerializeField] private LayerMask waterMask;

    [SerializeField] AudioManager _playerAudioManager;
    [SerializeField] AudioClip _waterLoop;

    int _sfxId = -1;

    private bool _inAir=true, _inWater;

//    private void Update()
  //  {
    //    _inWater = Physics2D.BoxCast(transform.position, Vector2.one * 0.5f, 0, Vector2.down, 0.3f, waterMask);
    //  _inAir = !_inWater;
    //}

    public bool CheckIsInWater()
    {
        return _inWater;
    }

    public bool CheckIsInAir()
    {
        return _inAir;
    }

    private void OnWaterStay()
    {
        Debug.Log("In water");
        _inWater = true;
        if(_sfxId<0)
            _sfxId = _playerAudioManager.PlaySFXLoop(_waterLoop,true);
        _inAir = !_inWater;
        anim.SetWater(_inWater);
    }

    private void OnWaterExit()
    {
        Debug.Log("Out water");
        _inWater = false;
        if(_sfxId>=0){
            _playerAudioManager.StopSFXLoop(_sfxId);
            _sfxId = -1;
        }
        _inAir = !_inWater;
        anim.SetWater(_inWater);
    }

}
