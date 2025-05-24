using UnityEngine;

public class Parallax : MonoBehaviour {
    private float speed;

    private void Start() {
        speed = transform.parent.GetComponent<ParallaxManager>().parallaxSpeed;
    }

    private void Update() {
        if (!GameManager.Instance.gameStarted) {
            return;
        }

        if (transform.position.x <= -40) {
            Destroy(gameObject);
        }

        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}