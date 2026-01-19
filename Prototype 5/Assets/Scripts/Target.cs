using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public AudioClip audioClip;
   
    private float minSpeed = 12f;
    private float maxSpeed = 15f;

    
    private float maxTorque = 1f;

    private float xRange = 4f;
    private float ySpawnPos = -1f;

    public int pointValue;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rb.AddForce(RandomForce() , ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);

        }
    }   

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }



    Vector3 RandomForce()
    {
       return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque); 
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

}
