using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] List<WorldChunk> _chunks;

    public static Action ChunkUpdate;

    void Start()
    {
        ReAssignNumbers();
    }

    public void EnteredChunk(int number){
        if(number==0){
            _chunks[_chunks.Count-1].transform.position=_chunks[0].transform.position+Vector3.left*62.22f;
            _chunks.Insert(0,_chunks[_chunks.Count-1]);
            _chunks.RemoveAt(_chunks.Count-1);
            ReAssignNumbers();
        }else if(number==_chunks.Count-1){
            _chunks[0].transform.position=_chunks[_chunks.Count-1].transform.position+Vector3.right*62.22f;
            _chunks.Add(_chunks[0]);
            _chunks.RemoveAt(0);
            ReAssignNumbers();
        }
        ChunkUpdate?.Invoke();
    }

    void ReAssignNumbers(){
        for(int i =0;i<_chunks.Count;i++){
            _chunks[i].SetChunkNumber(i);
        }
    }
}
