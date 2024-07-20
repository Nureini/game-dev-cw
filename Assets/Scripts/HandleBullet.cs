using UnityEngine;

public class HandleBullet : MonoBehaviour
{
    public float bulletSpeed = 50f;

    // The duration of how long a bullet will stay created for before destoryed
    // this is to make the code/game cleaner
    public float bulletDestroyTime = 1f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        // speed of bullet is applied to the foward direction bullet is facing
        rb.velocity = transform.forward * bulletSpeed;

        // bullet destroyed once bulletDestoryTime Reached. 
        Destroy(gameObject, bulletDestroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // if bullet hits the enemy gameobject it kills the enemy
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.KillEnemy();
            // the bullet used to kill the enemy is the one that is destroyed
            Destroy(gameObject);
        }
    }
}
