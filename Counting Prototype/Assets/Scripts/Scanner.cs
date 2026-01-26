using UnityEngine;
using TMPro;

public class Scanner : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public AudioClip goalSound; // Audio clip for goal sound effect
    public ParticleSystem goalEffect; // Particle system for goal effect

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

            Instantiate(goalEffect, other.transform.position, other.transform.rotation); // Play goal particle effect
            Destroy(other.gameObject); // Destroy the ball upon scoring
            AudioSource.PlayClipAtPoint(goalSound, Camera.main.transform.position); // Play goal sound effect
            Debug.Log("Goal!"); 
        }
    }
}
