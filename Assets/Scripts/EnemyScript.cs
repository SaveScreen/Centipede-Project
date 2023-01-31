using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector2 enemymovement;
    private int phase;
    public float timeuntilnext;
    private float timer;
    //Edges of screen x -11.5 and 11.5

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        phase = 0;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Phase 0 is going right
        if (phase == 0) {
           timer = 0.0f;
           if (transform.position.x <= 11.5) {
                transform.position = new Vector2(transform.position.x + speed,transform.position.y);
           }
           else {
                phase += 1;
           }
        }
        //Phase 1 is going down
        if (phase == 1) {
            timer += Time.deltaTime;
            if (timer <= timeuntilnext) {
                transform.position = new Vector2(transform.position.x,transform.position.y - speed);
            }
            else {
                phase += 1;
            }

        }
        //Phase 2 is going left
        if (phase == 2) {
            timer = 0.0f;
            if (transform.position.x >= -11.5) {
                transform.position = new Vector2(transform.position.x - speed,transform.position.y);
            }
            else {
                phase += 1;
            }
        }
        //Phase 3 is going down oncemore
         if (phase == 3) {
            timer += Time.deltaTime;
            if (timer <= timeuntilnext) {
                transform.position = new Vector2(transform.position.x,transform.position.y - speed);
            }
            else {
                phase = 0;
            }

        }
    }
}
