using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance { get; private set; }

    public float obstacleSpeed;
    public float obstacleYLimit;

    [SerializeField] private Transform obstacle;
    [SerializeField] private float spawnTime;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("More than one ObstacleManager instance!");
        }

        Instance = this;
    }

    public IEnumerator SpawnObstacles()
    {
        while(true) 
        {
            Transform newObstacle = Instantiate(obstacle, transform);

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
