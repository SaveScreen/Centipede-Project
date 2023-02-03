using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    //CONTROLS THE LEVEL SETUP AND RESPAWNS ENEMIES
    public GameObject levelbg1;
    public GameObject levelbg2;
    public GameObject wholedragon;
    private int stage;
    private PlayerScript p;
    public BarrierSpawning bs;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        p = player.GetComponent<PlayerScript>();
        stage = 1;
        levelbg2.SetActive(false);
        levelbg1.SetActive(true);  
    }

    // Update is called once per frame
    void Update()
    {
        if (stage % 2 == 0) {
            levelbg2.SetActive(true);
            levelbg1.SetActive(false);
        } else {
            levelbg2.SetActive(false);
            levelbg1.SetActive(true);
        }
    }

    public void ChangeLevel(int level) {
        stage += level;
        p.enemytotal = 10;
        bs.Generate();
        CreateDragon();
    }

    void CreateDragon() {
        Instantiate(wholedragon,new Vector2(-2.75f,11.5f),Quaternion.identity);
    }
}
