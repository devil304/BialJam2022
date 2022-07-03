using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int maxDuck;
    [SerializeField] private float timeBetweenSpawn = 1f;
    [SerializeField] private float minimuDistance;
    [SerializeField] private GameObject duckPrefab;
    [SerializeField] private LayerMask platformMask;

    private List<GameObject> ducks;

    void Start()
    {
        ducks = new List<GameObject>();

        InvokeRepeating("SpawnDuck", 0.5f, timeBetweenSpawn);
    }

    private void SpawnDuck()
    {
        if(ducks.Count >= maxDuck) return;

        GameObject newDuck = Instantiate(duckPrefab, GetRandomPoint(), Quaternion.identity);

        ducks.Add(newDuck);
    }

    public void RemoveDuck(GameObject duckToRemove)
    {
        for (var i = 0; i < ducks.Count; i++)
        {
            if(ducks[i] == duckToRemove) 
            {
                ducks.RemoveAt(i);
                return;
            }
        }
    }

    [SerializeField] private Transform ULPoint;
    [SerializeField] private Transform DRPoint;

    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;

    public Vector2 GetRandomPoint()
    {
        Vector2 newRandomPoint = new Vector2( Random.Range(ULPoint.position.x, DRPoint.position.x),Random.Range(DRPoint.position.y, ULPoint.position.y) );
        
        for (var i = 0; i < ducks.Count; i++)
        {
            if(Vector2.Distance(newRandomPoint, ducks[i].transform.position) < minimuDistance &&
                Physics2D.OverlapCircle(newRandomPoint, 3f,platformMask))
            {
                return GetRandomPoint();
            }
        }
        if(Vector2.Distance(newRandomPoint, player1.position) < minimuDistance) return GetRandomPoint();
        if(Vector2.Distance(newRandomPoint, player2.position) < minimuDistance) return GetRandomPoint();

        return newRandomPoint;
    }

}
