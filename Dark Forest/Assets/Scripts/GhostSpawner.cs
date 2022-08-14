using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float spawnDelay = 1f;

    float nextTimeToSpawn = 0f;

    public GameObject ghost;

    public GameObject clone;

    public Transform[] spawnPoints;

    public Transform player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            SpawnGhost();
            nextTimeToSpawn = Time.time + spawnDelay;
            SpawnTimerIncrease();
        }
    }

    void SpawnGhost()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        clone = Instantiate(ghost, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnTimerIncrease()
    {
        if (spawnDelay > 0.3f)
        {
            spawnDelay -= 0.005f;
        }
        else
        {
            spawnDelay = 0.3f;
        }
    }

}
