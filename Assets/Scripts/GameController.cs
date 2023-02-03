using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //CONTROLS THE LEVEL SETUP AND RESPAWNS ENEMIES
    public static GameController game;
    public GameObject levelbg1;
    public GameObject levelbg2;
    public GameObject wholedragon;
    public GameObject gameoverui;
    public int stage;
    private PlayerScript p;
    public BarrierSpawning bs;
    public Text stageui;
    private EnemyScript e;
    private GameObject dragon;
    
    public Text score;
    public Text hiscore;
    private int currentscore;
    //private GameObject player;
    // Start is called before the first frame update

    
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        p = player.GetComponent<PlayerScript>();
        dragon = GameObject.FindWithTag("Enemy");
        e = dragon.GetComponent<EnemyScript>(); 
        stage = 1;
        levelbg2.SetActive(false);
        levelbg1.SetActive(true);
        gameoverui.SetActive(false);
        currentscore = 0;
        stageui.text = "STAGE: " + stage.ToString(); 
        score.text = "SCORE: " + currentscore.ToString();
        //Set HiScore here
        PlayerPrefs.SetInt("Hiscore",10000);
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore").ToString();
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
        stageui.text = "STAGE: " + stage.ToString();

    }

    public void ChangeLevel(int level) {
        stage += level;
        ChangeScore(1000);
        p.enemytotal = 10;
        bs.amount = 10;
        bs.Generate();
        CreateDragon();
    }

    void CreateDragon() {
        Instantiate(wholedragon,new Vector2(-2.75f,11.5f),Quaternion.identity);
        //Destroy(temp,0.25f);
        //player.SetActive(true);
    }
    public void ChangeScore(int scorechange) {
        currentscore += scorechange;
        
        //    SCORECHART
        // 100 Per Body Part
        // 10 Per Barrier
        // 1000 Per Stage Completed
        if (currentscore >= PlayerPrefs.GetInt("Hiscore",0)) {
            ChangeHiScore();
        }
        score.text = "SCORE: " + currentscore.ToString();
        
        
    }
    void ChangeHiScore() {
        PlayerPrefs.SetInt("Hiscore",currentscore);
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore").ToString();
    }
}
