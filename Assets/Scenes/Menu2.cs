using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu2 : MonoBehaviour
{
  public void ButtonClicked()
  {
    SceneManager.LoadScene("MainScene");
  }

}
