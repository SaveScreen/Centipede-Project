using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{

    public float speed;

    //CONTROLS PLAYER MOVEMENT
    public InputAction PlayerController;

    //CONTROLS PLAYER FIRING
    
    public GameObject arrow;
   
    //private int currenthiscore;
    
    private Rigidbody2D rb;
    private Vector2 move;
    public float bulletspeed;
    private Animator anim;
    private GameObject game;
    private GameController gamecontrol;
    private EnemyScript enemy;
    private AudioSource sounds;
    public AudioClip hurt;
    private SpriteRenderer r;

    //DO NOT TOUCH IN INSPECTOR
    public bool dead;
    //private float timer;
    
   

    //GOT THE MOVEMENT WORKING
   
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        game = GameObject.FindWithTag("GameController");
        gamecontrol = game.GetComponent<GameController>();
        sounds = gameObject.GetComponent<AudioSource>();
        r = gameObject.GetComponent<SpriteRenderer>();
        GameObject enemytag = GameObject.FindWithTag("Enemy");
        enemy = enemytag.GetComponent<EnemyScript>();
        anim.speed = 0.5f;
        //timer = 0.0f;
        //timeuntilreset = 3.0f;
        
    }

    void OnEnable() {
        PlayerController.Enable();
    }

    void OnDisable() {
        PlayerController.Disable();
        
    }

    void Update() {
        //if not dead, move player and stuff
            //For moving the player
            move = PlayerController.ReadValue<Vector2>();
            //For firing arrows
            if (Input.GetKeyDown(KeyCode.Q)) {
                Bullets();
                anim.SetBool("Shooting",true);
            } else {
                anim.SetBool("Shooting",false);
            }

           
            //Restarts the game
            if (Input.GetKeyDown(KeyCode.R)) {
                //SceneManager.LoadScene("Level1");
                SceneManager.GetActiveScene();
            }

            //For debug purposes. Exits the game
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }  
        
    }

    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed, move.y * speed);      
        
    }

    void Bullets() {
        GameObject bulletobject = Instantiate(arrow, rb.position + Vector2.up * 1.5f, Quaternion.identity);
        BulletScript bullet = bulletobject.GetComponent<BulletScript>();

        bullet.FireBullet(Vector2.up, bulletspeed);
        
        
    }

    public void PlaySound(AudioClip sound) {
        sounds.PlayOneShot(sound);
    }

}
