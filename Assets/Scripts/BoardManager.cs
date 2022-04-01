using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
  // Start is called before the first frame update
  public static BoardManager Instance;
  private int Width = 3;
  private int Height = 3;
  public Point PointPrefab;
  public Line LinePrefab;

  public ScorePoint ScorePointPrefab;
  private void Awake()
  {
    Instance = this;
  }

  public void setHeightAndWidth(int n)
  {
    Debug.Log(n);
    this.Width = n;
    this.Height = n;
  }

  void Start()
  {
    int x = PlayerPrefs.GetInt("ene");
    Width = x;
    Height = x;
    Debug.Log('x' + Width);
    GenerateBoard();
    

  }

  void Update()
  {

  }

  private void GenerateBoard()
  {
    for (int i = 0; i < Height; i++)
    {
      for (int j = 0; j < Width; j++)
      {
        var pointPosition = new Vector2(i, j);
        Instantiate(PointPrefab, pointPosition, Quaternion.identity);

        if (j != Width - 1)
        {
          if (i != Width - 1)
          {
            var scorePointPosition = new Vector2(i + 0.5f, j + 0.5f);
            var scorePoint = Instantiate(ScorePointPrefab, scorePointPosition, Quaternion.identity);
          }
          var verticalLinePosition = new Vector2(i, j - 0.20f);
          var verticalLine = Instantiate(LinePrefab, verticalLinePosition, Quaternion.identity);
          verticalLine.Init(verticalLinePosition);
        }

        if (i != 0)
        {
          var horizontalLinePosition = new Vector2(i + 0.2f, j);
          var horizontalLine = Instantiate(LinePrefab, horizontalLinePosition, Quaternion.identity);
          horizontalLine.transform.Rotate(0f, 0f, 90f);
          horizontalLine.Init(horizontalLinePosition);
        }

      }
    }
    var center = new Vector2((float)Height / 2 - 0.5f, (float)Width / 2 - 0.5f);
    Camera.main.transform.position = new Vector3(center.x, center.y, -5);
  }

  public void SetLinePoint(Line l)
  {
    GameManager.Instance.SwitchPlayer();
  }
}
