using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pipePrefabs;
    [SerializeField]
    private GameObject foodPrefab;

    //private float pipeSpawnPeriod = 5f; // час у секундах між появою труб
    private float pipeCountdown;        // залишок часу до появи труби
    private float foodCountdown;        // залишок часу до появи "їжі"

    void Start()
    {
        pipeCountdown = GameState.pipePeriod;
        foodCountdown = pipeCountdown / 2f;
    }

    void Update()
    {
        pipeCountdown -= Time.deltaTime;
        if (pipeCountdown <= 0)
        {
            pipeCountdown = GameState.pipePeriod;
            foodCountdown = pipeCountdown / 2f;
            SpawnPipe();
        }

        if (foodCountdown > 0)
        {
            if (foodCountdown - Time.deltaTime <= 0)
            {
                SpawnFood();
                foodCountdown = 0;
            }
            else
            {
                foodCountdown -= Time.deltaTime;
            }
            //foodCountdown = GameState.pipePeriod;
           
        }
    }

    private void SpawnFood()
    {
        if (Random.value < 0.5f)
        {
            var food = GameObject.Instantiate(foodPrefab);
            food.transform.position = this.transform.position + Vector3.up * Random.Range(-3.25f, 4f);
        }

    }
    private void SpawnPipe()
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
