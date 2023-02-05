using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour
{
  private GameObject game;
  private GameController g;

  void Start () {
    game = GameObject.FindWithTag("GameController");
    g = game.GetComponent<GameController>();
  }

    public void PlayAgain()
    {
      SceneManager.LoadScene("Level1");
    }

    public void EndGame() {
        Application.Quit();
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue() {
      g.gamecontinue = true;
      
    }

}
