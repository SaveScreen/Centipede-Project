using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float speed;
    private Vector2 enemymovement;
    private int phase;
    private bool goingdown;
    public float timeuntilnext;
    private float timer;
    private PlayerScript player;
    


    //Edges of screen x -11.5 and 11.5

    void Start()
    {
        phase = 0;
        timer = 0.0f;
        goingdown = true;
        GameObject playertag = GameObject.FindWithTag("Player");
        player = playertag.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingdown == true) {
            if (transform.position.y >= -12.25) {
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
            else {
                goingdown = false;
                phase = 0;
            }
             
        }
        else if (goingdown == false) {
                if (transform.position.y <= 12.25) {
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
                            transform.position = new Vector2(transform.position.x,transform.position.y + speed);
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
                            transform.position = new Vector2(transform.position.x,transform.position.y + speed);
                        }
                        else {
                            phase = 0;
                        }

                    }
                } 
                else {
                    goingdown = true;
                    phase = 0;
                }
        }
       
    }

    void OnCollisionEnter2D(Collision2D other) {
        PlayerScript p = other.gameObject.GetComponent<PlayerScript>();
        p.ChangeHealth(-1);
    }

    public void Destroyed() {
        player.ChangeScore(100);
        Destroy(gameObject);
    }
}
