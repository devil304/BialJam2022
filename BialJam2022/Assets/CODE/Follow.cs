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

    void Update()
    {
        if(posHistory.Count==0 || (((Vector2)transform.position)-posHistory.Last()).sqrMagnitude > (0.25f*0.25f)){
            posHistory.Enqueue(transform.position);
        }
        if(posHistory.Count>100)
            posHistory.Dequeue();

        for(int i=0;i<_chickens.Count;i++){
            //_chickens[i].position = 
        }
    }
}
