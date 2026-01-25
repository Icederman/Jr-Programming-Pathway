using UnityEngine;
using TMPro;

public class Scanner : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public AudioClip goalSound;


    private void Start()
    {
        // Initialize the score
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Goal Check
        if (other.CompareTag("Ball"))
        {
            score += 1; // Increment score by 1
            scoreText.text = "Score: " + score; // Update score display

            Destroy(other.gameObject); // Destroy the ball upon scoring
            AudioSource.PlayClipAtPoint(goalSound, Camera.main.transform.position); // Play goal sound effect
            Debug.Log("Goal!"); 
        }
    }
}
