using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int maxDuck;
    [SerializeField] private float timeBetweenSpawn = 1f;
    [SerializeField] private float minimuDistance;
    [SerializeField] private GameObject duckPrefab;

    private List<GameObject> ducks;

    void Start()
    {
        ducks = new List<GameObject>();

        InvokeRepeating("SpawnDuck", 0.5f, timeBetweenSpawn);
    }

    private void SpawnDuck()
    {
        if(ducks.Count >= maxDuck) return;

        GameObject newDuck = Instantiate(duckPrefab, Vector3.zero, Quaternion.identity);

        ducks.Add(newDuck);
    }

    [SerializeField] private Transform ULPoint;
    [SerializeField] private Transform DRPoint;

    public Vector2 GetRandomPoint()
    {
        Vector2 newRandomPoint = new Vector2( Random.Range(ULPoint.position.x, DRPoint.position.x),Random.Range(DRPoint.position.y, ULPoint.position.y) );
        
        for (var i = 0; i < ducks.Count; i++)
        {
            if()
        }

        return Vector2.zero;
    }

}
