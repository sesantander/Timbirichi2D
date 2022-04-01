using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
  public Dropdown dropDown;
  private int nValue = 4;
  
  private void Start(){
    dropDown.onValueChanged.AddListener(delegate{
      selectedOptionHandler(dropDown);
    });
  }
  public void StartMenu()
  {
    selectedOptionHandler(dropDown);
    PlayerPrefs.SetInt("n", nValue);
    SceneManager.LoadScene("MainScene");
  }

  public void selectedOptionHandler(Dropdown sender){
    if(sender.value == 0){
      nValue = 3;
    }
    if(sender.value == 1){
      nValue = 4;
    }
    if(sender.value == 2){
      nValue = 5;
    }
    if(sender.value == 3){
      nValue = 6;
    }
    if(sender.value == 4){
      nValue = 7;
    }
    if(sender.value == 5){
      nValue = 8;
    }
  }

}
