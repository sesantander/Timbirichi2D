using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
  public GameObject Inner;
  public Vector2 _position;
  public Vector2 Pos => _position;
  public LayerMask LineLayer;
  bool SquareCompleted = false;

  void Start()
  {
    Inner.GetComponent<SpriteRenderer>().color = Color.black;
  }
  private void FixedUpdate()
  {
    Collider2D[] check = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 0.4f, LineLayer);
    if (check.Length == 4 && (GameManager.Instance.GetGameState != GameManager.GameState.start) && SquareCompleted == false)
    {
      Debug.Log("check" + check.Length);
      SquareCompleted = true;
      Debug.Log(GameManager.Instance.GetGameState);
      if(GameManager.Instance.GetGameState == GameManager.GameState.player1){
        Inner.GetComponent<SpriteRenderer>().color = Color.red;
      }
      if (GameManager.Instance.GetGameState == GameManager.GameState.player2)
      {
        Inner.GetComponent<SpriteRenderer>().color = Color.blue;
      }
      GameManager.Instance.IncreaseScore(GameManager.Instance.GetGameState);
      // GameManager.Instance.SwitchPlayer();
    }
  }
}
