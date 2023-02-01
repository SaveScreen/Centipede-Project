using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{

    private int barrierhealth;
    private PlayerScript p;

    // Start is called before the first frame update
    void Start()
    {
        barrierhealth = 2;
        GameObject playertag = GameObject.FindWithTag("Player");
        p = playertag.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (barrierhealth <= 0)
        {
            Destroyed();
        }


    }

    public void ChangeHealth(int change)
    {
        barrierhealth += change;
    }

    private void Destroyed()
    {
        p.ChangeScore(50);
        Destroy(gameObject);
    }
}
