using UnityEngine;

public class SecondEnemy : Enemy //INHERITANCE
{

    //ENCAPSULATION
    private float health = 100;

    private float Health
    {
        get { return health; }

        set
        {
            if(value >0)
            {
                health = value;
            }

            if (value<=0)
            {
                health = 0;
            }
        }
    }


    //POLYMORPHISM
    protected override void Start()
    {
        speed -= 1f;
        base.Start();
    }

    //POLYMORPHISM
    protected override void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        } 

        base.Update();
    }

    //POLYMORPHISM
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            AudioSource.PlayClipAtPoint(bulletHitSound, Camera.main.transform.position);
            Health -= 60;
            Debug.Log("Hit!");
        }
    }
}
