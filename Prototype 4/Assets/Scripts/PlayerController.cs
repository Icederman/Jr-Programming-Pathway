using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player
    float verticalInput;// Forward and backward movement input

    Rigidbody playerRb; // Reference to the player's Rigidbody
    public GameObject focalPoint; // Reference to the focal point for camera direction

    public bool hasPowerup; // Indicates if the player has a powerup
    private float powerupStrength = 15.0f; // Strength of the powerup effect
    public GameObject powerupIndicator; // Visual indicator for powerup status

    private AudioSource playerAudio; // Reference to the player's AudioSource
    public AudioClip powerupSound; // Sound played when powerup is collected


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        focalPoint = GameObject.Find("Focal Point");

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }


    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            playerAudio.PlayOneShot(powerupSound, 1.0f);
            Destroy(other.gameObject);

            hasPowerup = true;
            powerupIndicator.SetActive(true);
            

            StartCoroutine(PowerupCountdownRoutine());
        }
    }


    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);




            Debug.Log("Player has collided with: " + collision.gameObject.name + " with powerup set to" + hasPowerup);

        }



    }



}