using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public float speed;

    //CONTROLS PLAYER MOVEMENT
    public InputAction PlayerController;

    //CONTROLS PLAYER FIRING
    public InputAction PlayerFire;


    private Rigidbody2D rb;
    private Vector2 move;
    private float fire;
    private float timer;
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
        fire = PlayerFire.ReadValue<float>();
    }

    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed, move.y * speed);
                 
        
    }

    void Bullets() {
        
        
    }

   /**
    void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Walltag") {
            Debug.Log("Collision successful!");
        }
        
    }
    **/
}
