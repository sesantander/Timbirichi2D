using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{

  public void ButtonClicked()
  {
    SceneManager.LoadScene("MainScene");
  }

  public void StartMenu()
  {
    PlayerPrefs.SetInt("ene", 4);
    SceneManager.LoadScene("MainScene");
  }

}
