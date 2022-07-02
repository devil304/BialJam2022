using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChunk : MonoBehaviour
{
    WorldManager _worldManager;
    int _myChunkNumber=-1;

    void Awake()
    {
        _worldManager = GetComponentInParent<WorldManager>();
    }

    public void SetChunkNumber(int number){
        _myChunkNumber = number;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            _worldManager.EnteredChunk(_myChunkNumber);
        }
    }
}
