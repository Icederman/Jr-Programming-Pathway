using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player
    float verticalInput;// Forward and backward movement input

    Rigidbody playerRb; // Reference to the player's Rigidbody
   public GameObject focalPoint; // Reference to the focal point for camera direction

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        focalPoint = GameObject.Find("Focal Point");
    }


    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

    }
}
