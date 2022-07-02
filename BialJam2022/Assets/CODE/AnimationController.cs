using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void SetAir(bool state)
    {
        anim.SetBool("inAir", state);
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
