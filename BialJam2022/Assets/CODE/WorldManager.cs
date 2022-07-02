using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] List<WorldChunk> _chunks;
    [SerializeField] List<Transform> _waterChunks;


    public void EnteredChunk(int number){
        if(number==0){
            //_chunks[_chunks.Count-1]
        }else if(number==_chunks.Count-1){

        }
    }
}
