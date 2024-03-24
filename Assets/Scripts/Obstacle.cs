using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(15, Random.Range(-ObstacleManager.instance.obstacleYLimit, ObstacleManager.instance.obstacleYLimit));
    }

    private void Update()
    {
        transform.Translate(Vector2.left * ObstacleManager.instance.obstacleSpeed * Time.deltaTime);

        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
