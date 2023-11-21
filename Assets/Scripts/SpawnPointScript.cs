using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;

    private float pipeSpawnPeriod = 5f; // ��� � �������� �� ������ ����
    private float pipeCountdown;        // ������� ���� �� �����

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
        }
    }

    private void SpawnPoint()
    {
        var pipe = GameObject.Instantiate(pipePrefab); // ~ new pipePrefab
        pipe.transform.position =this.transform.position + Vector3.up*Random.Range(-1.4f,1.4f);
    }
}
