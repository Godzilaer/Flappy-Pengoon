using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float score;
    [SerializeField] private float jumpStrength, gravity;

    private Rigidbody2D rb;
    private bool gameStarted;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!gameStarted)
            {
                gameStarted = true;
                rb.gravityScale = gravity;
                
                StartCoroutine(ObstacleManager.instance.SpawnObstacles());
            }

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpStrength);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            score++;
            print(score);
        }
    }
}
