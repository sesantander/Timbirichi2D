using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
  // Start is called before the first frame update
  public static BoardManager Instance;
  public int Width = 4;
  public int Height = 4;
  public Point PointPrefab;
  public Line LinePrefab;

  private void Awake()
  {
    Instance = this;
  }

  void Start()
  {
    GenerateBoard();

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void GenerateBoard()
  {
    for (int i = 0; i < Height; i++)
    {
      for (int j = 0; j < Width; j++)
      {
        var p = new Vector2(i, j);
        var linePosition = new Vector2(i, j - 0.15f);
        var centerLine = new Vector2((float)i / 2 - 0.5f, (float)j / 2 - 0.5f);
        var point = Instantiate(PointPrefab, p, Quaternion.identity);
        var linea = Instantiate(LinePrefab, linePosition, Quaternion.identity);

        point.Init(p);
      }
    }
    var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);
    Camera.main.transform.position = new Vector3(center.x, center.y, -5);
  }

  public void SetPoint(Point p)
  {
    Debug.Log("Position " + p._position.x + " " + p._position.y);
    GameManager.Instance.SwitchPlayer();
  }
}
