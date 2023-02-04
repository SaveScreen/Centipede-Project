using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    public void FireBullet(Vector2 direction, float force) {
        rb2d.AddForce(direction * force);

    }

    void OnCollisionEnter2D(Collision2D other) {
        EnemyScript enemy = other.collider.GetComponent<EnemyScript>();
        BarrierScript barrier = other.collider.GetComponent<BarrierScript>();
        LionScript lion = other.collider.GetComponent<LionScript>();

        if (enemy != null) {
            enemy.Destroyed();
        }
        if (barrier != null)
        {
            barrier.ChangeHealth(-1);
        }
        if (lion != null) {
            lion.Destroyed();
        }
    
        //Bullet destroys itself once it hits an enemy
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        //Bullet destroys itself once it goes off screen
        if (transform.position.magnitude > 500.0f) {
            Destroy(gameObject);
        }
    }
}
