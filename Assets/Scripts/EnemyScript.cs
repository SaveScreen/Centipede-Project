using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float speed;
    private Vector2 enemymovement;
    private int phase;
    private bool goingdown;
    private PlayerScript player;
    private SpriteRenderer enemydirection;
    public AudioClip hitdragon;
    public AudioClip dragonroar;
    public AudioClip playerhurt;
    private float soundtimer;
    private float timeuntilsound;
    private GameController g;
    private Vector2 coords;
    private float newx;
    private float newy;
    
    


    //Edges of screen x -11.5 and 11.5

    void Start()
    {
        enemydirection = gameObject.GetComponent<SpriteRenderer>();
        enemydirection.flipX = true;
        speed = 8.0f;
        phase = 0;
        
        soundtimer = 0.0f;
        timeuntilsound = 0.5f;
        goingdown = true;
        GameObject playertag = GameObject.FindWithTag("Player");
        player = playertag.GetComponent<PlayerScript>();
        GameObject gctag = GameObject.FindWithTag("GameController");
        g = gctag.GetComponent<GameController>();
        
        if (g.stage >= 2) {
            speed = 9;
        }
        if (g.stage >= 5) {
            speed = 10;
        }
        if (g.stage >= 10) {
            speed = 12;
        }
        if (g.stage >= 15) {
            speed = 15;
        }
        if (g.stage >= 20) {
            speed = 18;
        }
        if (g.stage >= 25) {
            speed = 24;
        }
        if (g.stage >= 35) {
            speed = 30;
        }
        if (g.stage >= 50) {
            speed = 36;
        }
        if (g.stage >= 75) {
            speed = 42;
        }
        if (g.stage >= 100) {
            speed = 50;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if (goingdown == true) {
            if (transform.position.y >= -12.0f) {
                //Going right
                if (phase == 0) {
                    newx = 12.0f;
                    enemydirection.flipX = true;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(newx,transform.position.y), speed * Time.deltaTime);
                    if (transform.position.x >= 12.0f) {
                        phase += 1;
                        newy = transform.position.y - 1.0f;
                    }
                }
                //Going down
                if (phase == 1) {
                    enemydirection.flipX = true;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(transform.position.x,newy), speed * Time.deltaTime);
                    if (transform.position.y <= coords.y) {
                        phase += 1;
                        newx = -12.0f;
                    }
                }
                //Going left
                if (phase == 2) {
                    enemydirection.flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(newx,transform.position.y), speed * Time.deltaTime);
                    if (transform.position.x <= coords.x) {
                        phase += 1;
                        newy = transform.position.y - 1.0f;
                    }
                }
                //Going down again
                if (phase == 3) {
                    enemydirection.flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(transform.position.x,newy), speed * Time.deltaTime);
                    if (transform.position.y <= coords.y) {
                        phase = 0;
                    }
                }
            } else {
                phase = 0;
                goingdown = false;
            }
            
        }
        if (goingdown == false) {
            if (transform.position.y <= 12.0f) {
                //Going left
                if (phase == 0) {
                    newx = -12.0f;
                    enemydirection.flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(newx,transform.position.y), speed * Time.deltaTime);
                    if (transform.position.x <= -12.0f) {
                        phase += 1;
                        newy = transform.position.y + 1.0f;
                    }
                }
                //Going up
                if (phase == 1) {
                    enemydirection.flipX = false;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(transform.position.x,newy), speed * Time.deltaTime);
                    if (transform.position.y >= coords.y) {
                        phase += 1;
                        newx = 12.0f;
                    }
                }
                //Going right
                if (phase == 2) {
                    enemydirection.flipX = true;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(newx,transform.position.y), speed * Time.deltaTime);
                    if (transform.position.x >= coords.x) {
                        phase += 1;
                        newy = transform.position.y + 1.0f;
                    }
                }
                //Going up again
                if (phase == 3) {
                    enemydirection.flipX = true;
                    transform.position = Vector2.MoveTowards(transform.position, coords = new Vector2(transform.position.x,newy), speed * Time.deltaTime);
                    if (transform.position.y >= coords.y) {
                        phase = 0;
                    }
                }
            } else {
                phase = 0;
                goingdown = true;
            }
            
        }

        //OLD DRAGON PATH AI
        /****************************************************************************************************************
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
        ****************************************************************************************************/



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
                newy = transform.position.y - 1.0f;
            }
            if (phase == 1) {
                phase = 3;
                newy = transform.position.y - 1.0f;
            }
            if (phase == 2) {
                phase = 3;
                newy = transform.position.y - 1.0f;

            }
            if (phase == 3) {
                phase = 1;
                newy = transform.position.y - 1.0f;
            }
        }
        if (goingdown == false) {
            if (phase == 0) {
                phase = 1;
                newy = transform.position.y + 1.0f;
            }
            
            if (phase == 1) {
                phase = 3;
                newy = transform.position.y + 1.0f;
            }
            if (phase == 2) {
                phase = 3;
                newy = transform.position.y + 1.0f;
            }
            if (phase == 3) {
                phase = 1;
                newy = transform.position.y + 1.0f;
            }
           
        }
    }

    public void DestroyForRestart() {
        Destroy(gameObject);
    }
}
