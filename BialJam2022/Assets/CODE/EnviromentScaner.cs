using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentScaner : MonoBehaviour
{
    [SerializeField] private LayerMask waterMask;

    private bool _inAir, _inWater;

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
        _inAir = !_inWater;
    }

    private void OnWaterExit()
    {
        _inWater = false;
        _inAir = !_inWater;
    }

}
