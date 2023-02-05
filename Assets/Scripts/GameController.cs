using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //CONTROLS THE LEVEL SETUP AND RESPAWNS ENEMIES
    //This is the only persistent Gameobject that wont be destroyed at all.
    public static GameController game;
    public GameObject levelbg1;
    public GameObject levelbg2;
    public GameObject dragonshead;
    public GameObject dragonsleg;
    public GameObject dragonsbody;
    public GameObject dragonstail;
    public GameObject lion;
    private LionScript l;
    public int stage;
    private PlayerScript p;
    public BarrierSpawning bs;
    public Text stageui;
    private EnemyScript d;
    private GameObject dragon;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public GameObject life4;
    public GameObject life5;
    public GameObject life6;
    public GameObject life7;
    public GameObject life8;
    public GameObject life9;
    public Text score;
    public Text hiscore;
    public GameObject gameoverscreen;
    public GameObject youwinscreen;
    private int currentscore;
    private int maxhealth;
    private int currenthealth;
    private int currentscoreextralife;
    private int extralifescore;
    private GameObject player;
    public int enemytotal;
    private float liontimer;
    private float timeforlion;
    public AudioClip gameoversound;
    private AudioSource sounds;
    public bool gameover;
    private bool gameistrulyover;
    public AudioClip newlife;
    public bool gamecontinue;
    private GameObject b;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        p = player.GetComponent<PlayerScript>();
        dragon = GameObject.FindWithTag("Enemy");
        d = dragon.GetComponent<EnemyScript>(); 
        GameObject liontag = GameObject.FindWithTag("Lion");
        l = liontag.GetComponent<LionScript>();
        sounds = gameObject.GetComponent<AudioSource>();
        stage = 1;
        levelbg2.SetActive(false);
        levelbg1.SetActive(true);
        gameoverscreen.SetActive(false);
        youwinscreen.SetActive(false);
        currentscore = 0;
        currentscoreextralife = 0;
        //This is the score you need for an extra life.
        extralifescore = 20000;
        maxhealth = 9;
        currenthealth = 3;
        stageui.text = "STAGE: " + stage.ToString(); 
        score.text = "SCORE: " + currentscore.ToString();
        //Set HiScore here
        PlayerPrefs.SetInt("Hiscore",10000);
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore").ToString();
        enemytotal = 10;
        liontimer = 0.0f;
        timeforlion = 20.0f;
        gameover = false;
        gameistrulyover = false;
        gamecontinue = false;
        Time.timeScale = 1.0f;
        

        //Lifecount at start of game
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
        life4.SetActive(false);
        life5.SetActive(false);
        life6.SetActive(false);
        life7.SetActive(false);
        life8.SetActive(false);
        life9.SetActive(false);
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

        //GAME OVER
        if (gameover == false) {
            if (currenthealth <= 0) {
                gameover = true;
                
            }
        }
        if (gameover == true) {
            if (gameistrulyover == true) {
                Time.timeScale = 0.0f;
            } else {
                gameoverscreen.SetActive(true);
                PlaySound(gameoversound);
                gameistrulyover = true;
            }
            /*
            if (gameistrulyover == true) {
                //There's nothing left to do.
            } else {
                /*
                currenthealth = 0;
                player.SetActive(false);
                gameoverscreen.SetActive(true);
                GameObject[] dragonparts;
                dragonparts = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject drag in dragonparts) {
                    drag.SetActive(false);
                }
                lion.SetActive(false);
                PlaySound(gameoversound);
                gameistrulyover = true;
                }
            } 
            */
        }
        
         //Go to next level
        if (enemytotal < 1) {
            ChangeLevel(1);
            enemytotal = 10;
        }

        liontimer += Time.deltaTime;
        if (liontimer >= timeforlion) {
            CreateLion();
            lion.SetActive(true);
            liontimer = 0.0f;
        }

        if (gamecontinue == true) {
            ChangeLevel(1);
            
        }
        //YOU WIN
        /*
        if (stage == 3) {
            if (gamecontinue == false) {
                youwinscreen.SetActive(true);
                Time.timeScale = 0.0f;
            } else {
                youwinscreen.SetActive(false);
                Time.timeScale = 1.0f;
            }    
        }
        */

    }


    public void ChangeLevel(int level) {
        //YOU WIN SCREEN ONLY
        if (stage == 2) {
            if (gamecontinue == false) {
                youwinscreen.SetActive(true);
                Time.timeScale = 0.0f;
            } else {
                youwinscreen.SetActive(false);
                Time.timeScale = 1.0f;
                stage += level;
                ChangeScore(1000);
                bs.amount = 5;
                bs.Generate();
                CreateDragon();
                gamecontinue = false;
            } 
        } else {
            stage += level;
            ChangeScore(1000);
            bs.amount = 5;
            bs.Generate();
            CreateDragon();
        }
        
    }


    void CreateDragon() {
        Instantiate(dragonshead,new Vector2(-2.75f,11),Quaternion.identity);
        Instantiate(dragonsleg,new Vector2(-3.75f,11),Quaternion.identity);
        Instantiate(dragonsbody,new Vector2(-4.75f,11),Quaternion.identity);
        Instantiate(dragonsbody,new Vector2(-5.75f,11),Quaternion.identity);
        Instantiate(dragonsbody,new Vector2(-6.75f,11),Quaternion.identity);
        Instantiate(dragonsbody,new Vector2(-7.75f,11),Quaternion.identity);
        Instantiate(dragonsbody,new Vector2(-8.75f,11),Quaternion.identity);
        Instantiate(dragonsbody,new Vector2(-9.75f,11),Quaternion.identity);
        Instantiate(dragonsleg,new Vector2(-10.75f,11),Quaternion.identity);
        Instantiate(dragonstail,new Vector2(-11.75f,11),Quaternion.identity);
    }

    void CreateLion() {
        lion.SetActive(true);
        Instantiate(lion, new Vector2(-10.0f,-14.0f), Quaternion.identity);
    }


    public void ChangeScore(int scorechange) {
        currentscore += scorechange;
        currentscoreextralife += scorechange;

        //    SCORECHART
        // 100 Per Body Part
        // 10 Per Barrier
        // 1000 Per Stage Completed
        if (currentscore >= PlayerPrefs.GetInt("Hiscore",0)) {
            ChangeHiScore();
        }
        score.text = "SCORE: " + currentscore.ToString();

        if (currentscoreextralife >= extralifescore) {
            if (currenthealth < maxhealth) {
                ChangeHealth(1);
            }
            currentscoreextralife = 0;
        }
        
        
    }


    void ChangeHiScore() {
        PlayerPrefs.SetInt("Hiscore",currentscore);
        hiscore.text = "HI-SCORE: " + PlayerPrefs.GetInt("Hiscore").ToString();
    }

    public void RestartLevel() {
        GameObject[] dragonparts;
        dragonparts = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject drag in dragonparts) {
            drag.SetActive(false);
        }
        p.transform.position = new Vector2 (0,-10);
        enemytotal = 10;
        CreateDragon();
    }

    public void ChangeHealth(int amount) {
        currenthealth += amount;
        if (amount >= 1) {
            p.PlaySound(newlife);
        }
        
        if (currenthealth == 0) {
            life1.SetActive(false);
            life2.SetActive(false);
            life3.SetActive(false);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        if (currenthealth == 1) {
            life1.SetActive(true);
            life2.SetActive(false);
            life3.SetActive(false);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 2) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(false);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 3) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(false);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 4) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(false);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 5) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(false);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 6) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(false);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 7) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(true);
            life8.SetActive(false);
            life9.SetActive(false);
        }
        else if (currenthealth == 8) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(true);
            life8.SetActive(true);
            life9.SetActive(false);
        }
        else if (currenthealth == 9) {
            life1.SetActive(true);
            life2.SetActive(true);
            life3.SetActive(true);
            life4.SetActive(true);
            life5.SetActive(true);
            life6.SetActive(true);
            life7.SetActive(true);
            life8.SetActive(true);
            life9.SetActive(true);
        }
    }
    void PlaySound(AudioClip sound) {
        sounds.PlayOneShot(sound);
    }
}
