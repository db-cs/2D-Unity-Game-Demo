using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private bool spawnEnabled = true;
    [SerializeField] private float spawnMin = 2f;
    [SerializeField] private float spawnMax = 5f;
    [SerializeField] private float obstacleSpeed = 0.05f;
    
    private float currentTime;
    private float timeTillObstacle;


    private void Start()
    {
        currentTime = 0;
        timeTillObstacle = Random.Range(spawnMin, spawnMax);
    }

    private void Update()
    {
        if(GameLogic.instance.timeElapsed > 200)
        {
            obstacleSpeed = 0.15f;
            spawnMin = 1.5f;
            spawnMax = 4f;
        }
        if(spawnEnabled)
        { 
            currentTime += Time.deltaTime;

            if (currentTime > timeTillObstacle)
            {
                SpawnObstacle();
                timeTillObstacle = Random.Range(spawnMin, spawnMax);
                currentTime = 0;
            }
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = ObstaclePool.instance.GetPooledObject();

        if (obstacle != null)
        {
            obstacle.transform.position = transform.position;
            obstacle.GetComponent<MoveObstacle>().speed = obstacleSpeed;
            obstacle.SetActive(true);
        }
    }
}
