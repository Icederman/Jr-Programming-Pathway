using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Assign horizontal input from user 
        horizontalInput = Input.GetAxis("Horizontal");

        // Player movement 
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

    }
}
