using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float jumpStrength, gravity;

    private Rigidbody2D rb;
    private bool jumpRequest;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (GameManager.Instance.gameOver) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if (!GameManager.Instance.gameStarted) {
                GameManager.Instance.StartGame();
                rb.gravityScale = gravity;
            }

            jumpRequest = true;
        }
    }

    private void FixedUpdate() {
        if(jumpRequest) {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpStrength);

            jumpRequest = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (GameManager.Instance.gameStarted && collision.gameObject.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (GameManager.Instance.gameStarted && collision.gameObject.CompareTag("Checkpoint")) {
            GameManager.Instance.UpdateScore();
        }
    }
}
