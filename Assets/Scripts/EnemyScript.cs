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
    private SpriteRenderer enemydirection;
    public AudioClip hitdragon;
    public AudioClip dragonroar;
    public AudioClip playerhurt;
    private float soundtimer;
    private float timeuntilsound;
    private GameController g;
    
    


    //Edges of screen x -11.5 and 11.5

    void Start()
    {
        enemydirection = gameObject.GetComponent<SpriteRenderer>();
        enemydirection.flipX = true;
        phase = 0;
        timer = 0.0f;
        soundtimer = 0.0f;
        timeuntilsound = 0.5f;
        goingdown = true;
        GameObject playertag = GameObject.FindWithTag("Player");
        player = playertag.GetComponent<PlayerScript>();
        GameObject gctag = GameObject.FindWithTag("GameController");
        g = gctag.GetComponent<GameController>();
        if (g.stage >= 2) {
            speed = 0.01f;
        }
        if (g.stage >= 5) {
            speed = 0.0125f;
        }
        if (g.stage >= 10) {
            speed = 0.015f;
        }
        if (g.stage >= 15) {
            speed = 0.02f;
        }
        if (g.stage >= 20) {
            speed = 0.025f;
        }
        if (g.stage >= 25) {
            speed = 0.03f;
        }
        if (g.stage >= 35) {
            speed = 0.045f;
        }
        if (g.stage >= 50) {
            speed = 0.07f;
        }
        if (g.stage >= 75) {
            speed = 0.1f;
        }
        if (g.stage >= 100) {
            speed = 0.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (goingdown == true) {
            if (transform.position.y >= -12.25) {
                //Phase 0 is going right
                if (phase == 0) {
                timer = 0.0f;
                enemydirection.flipX = true;
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
                    enemydirection.flipX = false;
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
                    //Phase 0 is going left
                    if (phase == 0) {
                    timer = 0.0f;
                    enemydirection.flipX = true;
                    if (transform.position.x <= 11.5) {
                            transform.position = new Vector2(transform.position.x + speed,transform.position.y);
                    }
                    else {
                            phase += 1;
                    }
                    }
                    //Phase 1 is going up
                    if (phase == 1) {
                        timer += Time.deltaTime;
                        if (timer <= timeuntilnext) {
                            transform.position = new Vector2(transform.position.x,transform.position.y + speed);
                        }
                        else {
                            phase += 1;
                        }

                    }
                    //Phase 2 is going right
                    if (phase == 2) {
                        timer = 0.0f;
                        enemydirection.flipX = false;
                        if (transform.position.x >= -11.5) {
                            transform.position = new Vector2(transform.position.x - speed,transform.position.y);
                        }
                        else {
                            phase += 1;
                        }
                    }
                    //Phase 3 is going up oncemore
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

        //For dragon sounds
        soundtimer += Time.deltaTime;
        if (soundtimer >= timeuntilsound) {
           player.PlaySound(dragonroar);
            soundtimer = 0.0f;
            timeuntilsound = 10.0f; 
        }
       
    }

    void OnCollisionEnter2D(Collision2D other) {

        //Collision with Player
        PlayerScript p = other.gameObject.GetComponent<PlayerScript>();
        if (p != null) {
            g.ChangeHealth(-1);
            p.PlaySound(playerhurt);
            g.enemytotal -= 1;
            g.RestartLevel();
            Destroy(gameObject);
        }

        //Collision with Barriers
        if (other.gameObject.tag == "Barrier") {
            ChangeDirection();
        }
        
    }

    public void Destroyed() {
        g.ChangeScore(100);
        g.enemytotal -= 1;
        player.PlaySound(hitdragon);
        Destroy(gameObject);
    }

    void ChangeDirection() {
        if (goingdown == true) {
            if (phase == 0) {
                phase = 1;
            }
            if (phase == 2) {
                phase = 3;
            }
        }
        if (goingdown == false) {
            if (phase == 0) {
                phase = 1;
            }
            
            if (phase == 2) {
                phase = 3;
            }
           
        }
    }

}
