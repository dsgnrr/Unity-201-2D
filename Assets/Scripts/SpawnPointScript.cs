using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pipePrefabs;

    private float pipeSpawnPeriod = 5f; // час у секундах м≥ж по€вою труб
    private float pipeCountdown;        // залишок часу до по€ви

    void Start()
    {
        pipeCountdown = pipeSpawnPeriod; 
    }

    void Update()
    {
        pipeCountdown -= Time.deltaTime;
        if (pipeCountdown <= 0)
        {
            pipeCountdown = pipeSpawnPeriod;
            SpawnPoint();
            pipeSpawnPeriod = Random.Range(3f, 5f);
        }
    }

    private void SpawnPoint()
    {
        GameObject randomPrefab = GetRandomGameObject(pipePrefabs);
        if (randomPrefab != null)
        {
            var pipe = GameObject.Instantiate(randomPrefab);
            pipe.transform.position = this.transform.position + Vector3.up * Random.Range(-1.4f, 1.4f);
        }
    }
    static private GameObject GetRandomGameObject(GameObject[] gameObjects)
    {
        if (gameObjects.Length != 0)
        {
            return gameObjects[Random.Range(0, gameObjects.Length)];
        }
        return null;
    }
}
