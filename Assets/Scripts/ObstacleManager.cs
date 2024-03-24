using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance { get; private set; }

    public float obstacleSpeed;
    public float obstacleYLimit;

    [SerializeField] private Transform obstacle;
    [SerializeField] private float spawnTime;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one ObstacleManager instance!");
        }

        instance = this;
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
