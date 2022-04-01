using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
  public GameObject Inner;
  public Vector2 _position;
  public Vector2 Pos => _position;

  public void Init(Vector2 position)
  {
    this._position = position;
  }

  public LayerMask SquarePointLayer;
  void Start()
  {
    Inner.GetComponent<SpriteRenderer>().color = Color.black;
  }

  private void OnMouseDown()
  {
    var shu = new Vector2(0.1f, 0f);
    GetComponent<CapsuleCollider2D>().size += shu;

    if (GameManager.Instance.GetGameState == GameManager.GameState.player1)
    {
      Inner.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    else
    {
      Inner.GetComponent<SpriteRenderer>().color = Color.red;
    }
    BoardManager.Instance.SetLinePoint(this);
  }
}
