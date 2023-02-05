using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour
{
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

}
