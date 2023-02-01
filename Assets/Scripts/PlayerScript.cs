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
    public Text score;
    public Text hiscore;
    private int currentscore;
    public int maxhealth;
    private int currenthealth;
    private Rigidbody2D rb;
    private Vector2 move;
    public float bulletspeed;
    //private float fire;
    //private float timer;
    //public float firedelay;
    //Determines how many bullets on screen
    //private int bulletsonscreen;
    //stops fireing when set to True
    //private bool holdfire;

    //GOT THE MOVEMENT WORKING
   
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currenthealth = maxhealth;
        score.text = "SCORE: " + currentscore.ToString();
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore",0).ToString();
        //bulletsonscreen = 0;
        //holdfire = false;
    }

    void OnEnable() {
        PlayerController.Enable();
    }

    void OnDisable() {
        PlayerController.Disable();
        
    }

    void Update() {
        move = PlayerController.ReadValue<Vector2>();
        //fire = PlayerFire.ReadValue<float>();

        //Restarts the game
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("SampleScene");
        }

        //For debug purposes. Exits the game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }

        //For firing arrows
        if (Input.GetKeyDown(KeyCode.Q)) {
            Bullets();
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
        Debug.Log("OUCH!!");
    }

    public void ChangeScore(int scorechange) {
        currentscore += scorechange;
        //    SCORECHART
        // 100 Per Body Part
        // 50 Per Barrier
        if (currentscore > PlayerPrefs.GetInt("Hiscore",0)) {
            hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore",currentscore).ToString();
        }
        score.text = "Score: " + currentscore.ToString();
        
    }

   /**
    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Walltag") {
            Debug.Log("Collision successful!");
        }
        
    }
    **/
}
