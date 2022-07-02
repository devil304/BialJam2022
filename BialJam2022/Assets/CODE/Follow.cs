using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Queue<Vector2> posHistory = new Queue<Vector2>();

    [SerializeField] List<Transform> _chickens = new List<Transform>();

    public void AddChicken(Transform chicken){
        _chickens.Add(chicken);
    }

    [SerializeField] float _maxMag = 0;

    void Update()
    {
        var mag = posHistory.Count>0?(((Vector2)transform.position)-posHistory.Last()).magnitude:0;
        if(posHistory.Count==0 || mag > 0.25f){
            if(mag>=0.5f && posHistory.Count>0){
                for(float i=0.25f;i<mag;i+=0.25f)
                    posHistory.Enqueue(posHistory.Last()+(((Vector2)transform.position-posHistory.Last()).normalized*0.25f));
            }else
                posHistory.Enqueue(posHistory.Count>0?posHistory.Last()+(((Vector2)transform.position-posHistory.Last()).normalized*0.25f):transform.position);
        }
        if(mag>_maxMag)
            _maxMag = mag;
        if(posHistory.Count>70)
            posHistory.Dequeue();

        if(posHistory.Count<(8+_chickens.Count*4)) return;

        for(int i=0;i<_chickens.Count;i++){
            var pos = Vector2.zero;
            if(i==0){
                pos = Vector2.Lerp(posHistory.ToArray()[posHistory.Count-6],posHistory.ToArray()[posHistory.Count-5],(mag%0.25f)/0.25f);
            }else{
                pos = Vector2.Lerp(posHistory.ToArray()[posHistory.Count-6-(i*4)],posHistory.ToArray()[posHistory.Count-5-(i*4)],(mag%0.25f)/0.25f);
            }
            _chickens[i].position = pos;
        }
    }
}
