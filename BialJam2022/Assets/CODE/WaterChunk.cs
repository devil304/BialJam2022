using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChunk : MonoBehaviour
{
    [SerializeField] Transform _linkedGround;

    Vector2 _offset;

    void Awake()
    {
        _offset = _linkedGround.InverseTransformPoint(transform.position);
        WorldManager.ChunkUpdate += WorldUpdate;
    }

    private void WorldUpdate()
    {
        transform.position = _linkedGround.TransformPoint(_offset);
    }
}
