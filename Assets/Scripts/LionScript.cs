using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour
{
    //Path goes in a sawtooth pattern
    private Vector2 defaultpos = new Vector2(-10.0f,-13.0f);
    private Vector2 path1p1 = new Vector2(-10.0f,-4.5f);
    private Vector2 path1p2 = new Vector2(-3.5f,-11.5f);
    private Vector2 path1p3 = new Vector2(-3.5f,-4.5f);
    private Vector2 path1p4 = new Vector2(4.0f,-11.5f);
    private Vector2 path1p5 = new Vector2(4.0f,-4.5f);
    private Vector2 path1p6 = new Vector2(13.0f,-11.5f);

    //Path goes in a giant box
    private Vector2 path2p1 = new Vector2(-10.0f,-11.5f);
    private Vector2 path2p2 = new Vector2(-10.0f,-7.5f);
    private Vector2 path2p3 = new Vector2(11.5f,-7.5f);
    private Vector2 path2p4 = new Vector2(11.5f,-11.5f);
    private Vector2 path2p5 = new Vector2(-10.0f,-11.5f);

    //Path that follows player.x for a few seconds, and then dives towards the player
    private Vector2 path3p1 = new Vector2(-10.0f,-4.5f);
    public GameObject playerpos;
    private PlayerScript player;
    private GameController g;
    public AudioClip hit;
    public float speed;
    private float choice;
    //private int phase;

    void Start() {
        playerpos.GetComponent<Transform>();
        //phase = 0;
        GameObject p = GameObject.FindWithTag("Player");
        player = p.GetComponent<PlayerScript>();
        GameObject game = GameObject.FindWithTag("GameController");
        g = game.GetComponent<GameController>();
        choice = 0;
        //choice = Mathf.Round(Random.Range(0,2));
        transform.position = defaultpos;
    }

    void Update() {
        if (choice == 0) {
            transform.position = Vector2.MoveTowards(defaultpos,path1p1,speed * Time.deltaTime);
           
        }

    }


    public void Destroyed() {
        g.ChangeScore(250);
        player.PlaySound(hit);
        Destroy(gameObject);
    }
}
