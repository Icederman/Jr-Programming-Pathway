using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button startButton; // Reference to the Start Button
    public GameObject titleScreen; // Reference to the Title Screen

    public Button restartButton; // Reference to the Restart Button
    public GameObject gameOverScreen; // Reference to the Game Over Screen
    public AudioClip gameOverSound; // Reference to the Game Over Sound

    public TextMeshProUGUI livesText; // Reference to the Lives Text
    public int lives = 3; // Initial number of lives

    public TextMeshProUGUI scoreText; // Reference to the Score Text

    public bool gameStarted = false; // Flag to check if the game has started

    private int ballCount; // To keep track of the number of balls in the scene
    public GameObject ballPrefab; // Reference to the ball prefab to be spawned

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Add listener to the start button to call StartGame and restart button to call RestartButton
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartButton);

        // Initialize lives text
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        // Count the number of balls currently in the scene
        ballCount = GameObject.FindGameObjectsWithTag("Ball").Length;

        // If there are no balls, spawn a new one
        if (ballCount == 0 && gameStarted)
        {
            SpawnBall();
        }

        // If lives reach zero, trigger game over
        if (lives == 0)
        {
            GameOver();
        }

    }


    void StartGame()
    {
        gameStarted = true;
        titleScreen.SetActive(false);
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, ballPrefab.transform.position, ballPrefab.transform.rotation);
    }

    public void UpdateLives()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        gameStarted = false;
        gameOverScreen.SetActive(true);
        AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, 0.3f);

    }



    void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}