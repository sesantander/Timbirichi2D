using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
  private GameState _gameState;
  public TextMeshProUGUI Player1Score;
  public TextMeshProUGUI Player2Score;

  int player1Score = 0;
  int player2Score = 0;
  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    _gameState = GameState.start;
  }
  public void UpdateGameState(GameState gameState)
  {
    _gameState = gameState;
  }
  public GameState GetGameState => _gameState;
  public void SwitchPlayer()
  {
    if (_gameState == GameState.player1)
    {
      _gameState = GameState.player2;
    }
    else
    {
      _gameState = GameState.player1;
    }
  }

  void Update()
  {
    switch (_gameState)
    {
      case GameState.start:
        UpdateGameState(GameState.player1);
        break;
      case GameState.player1:
        break;
      case GameState.player2:
        break;
      case GameState.end:
        break;
    }
  }

  public void IncreaseScore(GameState gamestate)
  {
    if (gamestate == GameState.player1)
    {
      player1Score++;
      Debug.Log("Blue" + player1Score);
      Player1Score.text = "Player A Score: " + player1Score.ToString();
    }
    if (gamestate == GameState.player2)
    {
      player2Score++;
      Debug.Log("Rojo " + player2Score);
      Player2Score.text = "Player B Score: " + player2Score.ToString();
    }
  }

  public enum GameState
  {
    start,
    player1,
    player2,
    end
  }
}
