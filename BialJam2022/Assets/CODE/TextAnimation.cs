using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 punchForce;
    [SerializeField] private float duration;

    void Start()
    {
        transform.DOPunchScale(punchForce, duration).Loops();
    }
}
