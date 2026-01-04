using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float Bound = 30.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > Bound)
        {
            Destroy(gameObject);

        }

        else if (transform.position.z < -Bound)
        {
            Destroy(gameObject);
        }
    }
}
