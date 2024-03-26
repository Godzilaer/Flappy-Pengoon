using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text scoreText, newHighScoreText, gameOverScoreText, highScoreText;
    [SerializeField] private Button retryButton;

    public bool gameStarted, gameOver;
    public int score;

    private Coroutine spawnObstaclesCoroutine;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("More than one GameManager singleton");
        }

        Instance = this;
    }

    private void Start()
    {
        retryButton.onClick.AddListener(Retry);
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void StartGame()
    {
        gameStarted = true;

        spawnObstaclesCoroutine = StartCoroutine(ObstacleManager.Instance.SpawnObstacles());
    }

    public void GameOver()
    {
        gameStarted = false;
        gameOver = true;
        StopCoroutine(spawnObstaclesCoroutine);

        gameOverScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverScoreText.text = "Score: " + score;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if(score > highScore)
        {
            newHighScoreText.gameObject.SetActive(true);
            highScore = score;
        }

        highScoreText.text = "High Score: " + highScore;
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
