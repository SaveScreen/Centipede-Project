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
    public int maxhealth;
    private int currenthealth;
    private Rigidbody2D rb;
    private Vector2 move;
    public float bulletspeed;
    private Animator anim;
    public int enemytotal;
    private GameObject game;
    private GameController gamecontrol;
    private EnemyScript enemy;
    private AudioSource sounds;
    public AudioClip hurt;
    private SpriteRenderer r;
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
        currenthealth = maxhealth;
        enemytotal = 10;
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
            move = PlayerController.ReadValue<Vector2>();
            //fire = PlayerFire.ReadValue<float>();

            
            //Restarts the game
            if (Input.GetKeyDown(KeyCode.R)) {
                //SceneManager.LoadScene("Level1");
                SceneManager.GetActiveScene();
            }

            //For debug purposes. Exits the game
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }

            //For firing arrows
            if (Input.GetKeyDown(KeyCode.Q)) {
                Bullets();
                anim.SetBool("Shooting",true);
            } else {
                anim.SetBool("Shooting",false);
            }
            
            //Go to next level
            if (enemytotal < 1) {
                gamecontrol.ChangeLevel(1);
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

    public void ChangeHealth(int amount) {
        currenthealth += amount;
    }

    public void PlaySound(AudioClip sound) {
        sounds.PlayOneShot(sound);
    }

   /**
    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Walltag") {
            Debug.Log("Collision successful!");
        }
        
    }
    **/
}
