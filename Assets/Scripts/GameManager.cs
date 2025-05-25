using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverScreen, newHighScoreObj, greetingObj;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private TextMeshProUGUI scoreText, gameOverScoreText, highScoreText;
    [SerializeField] private Button retryButton;

    public bool gameStarted, gameOver;
    public int score;

    private Coroutine spawnObstaclesCoroutine;

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("More than one GameManager singleton");
            Destroy(this);
        }

        Instance = this;
    }

    private void Start() {
        retryButton.onClick.AddListener(Retry);
    }

    public void UpdateScore() {
        score++;
        scoreText.text = score.ToString();
    }

    public void StartGame() {
        gameStarted = true;
        greetingObj.SetActive(false);
        spawnObstaclesCoroutine = StartCoroutine(ObstacleManager.Instance.SpawnObstacles());
    }

    public void GameOver() {
        gameStarted = false;
        gameOver = true;
        StopCoroutine(spawnObstaclesCoroutine);

        gameOverScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverScoreText.text = "Score: " + score;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore) {

            highScore = score;
            StartCoroutine(NewHighScoreAnimation());
        }

        highScoreText.text = "High Score: " + highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator NewHighScoreAnimation() {
        WaitForSeconds wait = new(0.7f);

        while (true) {
            newHighScoreObj.SetActive(true);
            yield return wait;
            newHighScoreObj.SetActive(false);
            yield return wait;
        }
    }
}
