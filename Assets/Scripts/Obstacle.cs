using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(15, Random.Range(-ObstacleManager.Instance.obstacleYLimit, ObstacleManager.Instance.obstacleYLimit));
    }

    private void Update()
    {
        if (GameManager.Instance.gameOver) return;

        transform.Translate(Vector2.left * ObstacleManager.Instance.obstacleSpeed * Time.deltaTime);

        if(transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
