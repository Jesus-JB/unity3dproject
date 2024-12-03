using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 2.0f;
    public float spawnDistance = 10.0f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Vector3 spawnPosition = player.position + player.forward * spawnDistance;
            int randomIndex = Random.Range(0, obstaclePrefabs.Length); // Seleccionar aleatoriamente un prefab
            Instantiate(obstaclePrefabs[randomIndex], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
