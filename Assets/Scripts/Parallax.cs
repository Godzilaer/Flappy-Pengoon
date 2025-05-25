using UnityEngine;

public class Parallax : MonoBehaviour {
    private float speed;

    private void Start() {
        speed = transform.parent.GetComponent<ParallaxManager>().parallaxSpeed;
    }

    private void FixedUpdate() {
        if (!GameManager.Instance.gameStarted) {
            return;
        }

        if (transform.position.x <= -40f) {
            Destroy(gameObject);
        }

        transform.Translate(speed *  Vector2.left);
    }
}