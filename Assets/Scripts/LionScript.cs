using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour
{
    //Path goes in a sawtooth pattern
    public Vector2 defaultpos = new Vector2(-10.0f,-14.0f);
    private Vector2 path1p1 = new Vector2(-10.0f,-4.5f);
    private Vector2 path1p2 = new Vector2(-3.5f,-11.5f);
    private Vector2 path1p3 = new Vector2(-3.5f,-4.5f);
    private Vector2 path1p4 = new Vector2(4.0f,-11.5f);
    private Vector2 path1p5 = new Vector2(4.0f,-4.5f);
    private Vector2 path1p6 = new Vector2(13.0f,-14.5f);

    //Path goes in a giant box
    private Vector2 path2p1 = new Vector2(-10.0f,-7.5f);
    private Vector2 path2p2 = new Vector2(11.5f,-7.5f);
    private Vector2 path2p3 = new Vector2(11.5f,-11.5f);
    private Vector2 path2p4 = new Vector2(-10.0f,-11.5f);
    private Vector2 path2p5 = new Vector2(-10.0f,-14.5f);

    //Path that follows player.x for a few seconds, and then dives towards the player
    private Vector2 path3p1 = new Vector2(-10.0f,-4.5f);
    public GameObject playerpos;
    private PlayerScript player;
    private GameController g;
    public AudioClip hit;
    public float spd;
    private float choice;
    private Animator anim;
    private int phase;
    private float timer;
    private float timeuntilstrike;
    private Vector2 positionnew;
    public AudioClip playerhurt;

    void Start() {
        playerpos.GetComponent<Transform>();
        anim = gameObject.GetComponent<Animator>();
        phase = 0;
        GameObject p = GameObject.FindWithTag("Player");
        player = p.GetComponent<PlayerScript>();
        GameObject game = GameObject.FindWithTag("GameController");
        g = game.GetComponent<GameController>();
        timer = 0.0f;
        timeuntilstrike = 4.0f;
        choice = Mathf.Round(Random.Range(0,2));
        transform.position = defaultpos;
        anim.speed = 0.5f;
        positionnew = playerpos.transform.position;

        if (g.stage >= 2) {
            spd = 5;
        }
        if (g.stage >= 5) {
            spd = 6;
        }
        if (g.stage >= 10) {
            spd = 8;
        }
        if (g.stage >= 15) {
            spd = 12;
        }
        if (g.stage >= 20) {
            spd = 16;
        }
        if (g.stage >= 25) {
            spd = 22;
        }
        if (g.stage >= 35) {
            spd = 28;
        }
        if (g.stage >= 50) {
            spd = 34;
        }
        if (g.stage >= 75) {
            spd = 40;
        }
        if (g.stage >= 100) {
            spd = 50;
        }
    }

    void Update() {
        //Goes in sawtooth pattern
        if (choice == 0) {
            if (phase == 0) {
                transform.position = Vector2.MoveTowards(transform.position, path1p1 , spd * Time.deltaTime);
                if (transform.position.y == path1p1.y) {
                    phase += 1;
                }
            }
            if (phase == 1) {
                transform.position = Vector2.MoveTowards(transform.position, path1p2 , spd * Time.deltaTime);
                if (transform.position.x == path1p2.x) {
                    phase += 1;
                }
            }
            if (phase == 2) {
                transform.position = Vector2.MoveTowards(transform.position, path1p3 , spd * Time.deltaTime);
                if (transform.position.y == path1p3.y) {
                    phase += 1;
                }
            }
            if (phase == 3) {
                transform.position = Vector2.MoveTowards(transform.position, path1p4 , spd * Time.deltaTime);
                if (transform.position.x == path1p4.x) {
                    phase += 1;
                }
            }
            if (phase == 4) {
                transform.position = Vector2.MoveTowards(transform.position, path1p5 , spd * Time.deltaTime);
                if (transform.position.y == path1p5.y) {
                    phase += 1;
                }
            }
            if (phase == 5) {
                transform.position = Vector2.MoveTowards(transform.position, path1p6 , spd * Time.deltaTime);
                if (transform.position.y == path1p6.y) {
                    Destroy(gameObject);
                }
            }
            
            
        }

        //Goes in a rectangle
        if (choice == 1) {
             if (phase == 0) {
                transform.position = Vector2.MoveTowards(transform.position, path2p1 , spd * Time.deltaTime);
                if (transform.position.y == path2p1.y) {
                    phase += 1;
                }
            }
            if (phase == 1) {
                transform.position = Vector2.MoveTowards(transform.position, path2p2 , spd * Time.deltaTime);
                if (transform.position.x == path2p2.x) {
                    phase += 1;
                }
            }
            if (phase == 2) {
                transform.position = Vector2.MoveTowards(transform.position, path2p3 , spd * Time.deltaTime);
                if (transform.position.y == path2p3.y) {
                    phase += 1;
                }
            }
            if (phase == 3) {
                transform.position = Vector2.MoveTowards(transform.position, path2p4 , spd * Time.deltaTime);
                if (transform.position.x == path2p4.x) {
                    phase += 1;
                }
            }
            if (phase == 4) {
                transform.position = Vector2.MoveTowards(transform.position, path2p5 , spd * Time.deltaTime);
                if (transform.position.y == path2p5.y) {
                    Destroy(gameObject);
                }
            }
        }

        //Tries to strike the player
        if (choice == 2) {
            if (phase == 0) {
                transform.position = Vector2.MoveTowards(transform.position, path3p1 , spd * Time.deltaTime);
                if (transform.position.y == path3p1.y) {
                    phase += 1;
                }
            }
            if (phase == 1) {
                //Wait
                timer += Time.deltaTime;
                if (timer >= timeuntilstrike) {
                    phase += 1;
                }
            }
            if (phase == 2) {
                Speedchange(2);
                FindPosition();
                phase += 1;
                
            }
            if (phase == 3) {
                transform.position = Vector2.MoveTowards(transform.position,positionnew,spd * Time.deltaTime);
                if (transform.position.x == positionnew.x) {
                    phase += 1;
                }
            }
            if (phase == 4) {
                transform.position = Vector2.MoveTowards(transform.position,new Vector2(transform.position.x,-14.5f),spd * Time.deltaTime);
                if (transform.position.y == -14.5f) {
                    Destroy(gameObject);
                }
            }
            
            
        }
            
    }


    public void Destroyed() {
        g.ChangeScore(250);
        player.PlaySound(hit);
        Destroy(gameObject);
    }

    public void Speedchange(int change) {
        spd += change;
    }

    void FindPosition() {
       positionnew = playerpos.transform.position;
    }

    public void OnCollisionEnter2D(Collision2D other) {
        PlayerScript pl = other.gameObject.GetComponent<PlayerScript>();
        if (pl != null) {
            g.ChangeHealth(-1);
            player.PlaySound(playerhurt);
            g.RestartLevel();
            Destroy(gameObject);
        }

    }
}
