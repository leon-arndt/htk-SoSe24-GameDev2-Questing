using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minSecondsBetweenSpawns = 1f;
    [SerializeField] private float maxSecondsBetweenSpawns = 2f;
    private float _timeToNextSpawn;

    [SerializeField] private List<GameObject> prefabs;

    private void Update()
    {
        _timeToNextSpawn -= Time.deltaTime;
        if (_timeToNextSpawn <= 0f)
        {
            Spawn();
            _timeToNextSpawn = UnityEngine.Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);
        }
    }

    private void Spawn()
    {
        var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Count)];
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}