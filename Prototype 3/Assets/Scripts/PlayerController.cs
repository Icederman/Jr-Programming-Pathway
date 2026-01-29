using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private Animator playerAnim;

    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    public float jumpForce = 10.0f;
    private bool isOnGround = true;
    public float gravityModifier;
    public bool gameOver;

    public GameObject explosionEffect;
    public ParticleSystem dirtEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            
        }

     
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            dirtEffect.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
            dirtEffect.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }


    }




}
