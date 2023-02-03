using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{

    private int barrierhealth;
    private PlayerScript p;
    public AudioClip barrierhit;
    private Animator anim;
    private GameController g;

    // Start is called before the first frame update
    void Start()
    {
        barrierhealth = 2;
        GameObject playertag = GameObject.FindWithTag("Player");
        p = playertag.GetComponent<PlayerScript>();
        GameObject gctag = GameObject.FindWithTag("GameController");
        g = gctag.GetComponent<GameController>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (barrierhealth <= 0)
        {
            Destroyed();
        }
        anim.speed = 0.5f;

    }

    public void ChangeHealth(int change)
    {
        barrierhealth += change;
        p.PlaySound(barrierhit);
    }

    private void Destroyed()
    {
        g.ChangeScore(10);
        p.PlaySound(barrierhit);
        Destroy(gameObject);
    }
}
