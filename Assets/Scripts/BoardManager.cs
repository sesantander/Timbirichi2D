using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
  // Start is called before the first frame update
  public static BoardManager Instance;
  private int Width;
  private int Height;
  public Point PointPrefab;
  public Line LinePrefab;

  public ScorePoint ScorePointPrefab;

  [SerializeField] float boundingBoxPadding = 2f;
  [SerializeField] float minimumOrthographicSize = 1f;
  private List<Transform> targets = new List<Transform>();
  private void Awake()
  {
    Instance = this;
  }

  public int GetWidth()
  {
    return this.Width;
  }
  public int GetHeight()
  {
    return this.Height;
  }

  void Start()
  {
    int n = PlayerPrefs.GetInt("n");
    Width = n;
    Height = n;
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
        var point = Instantiate(PointPrefab, pointPosition, Quaternion.identity);
        targets.Add(point.transform);

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
    Rect boundingBox = CalculateTargetsBoundingBox();
    Camera.main.orthographicSize = CalculateOrthographicSize(boundingBox);
  }

  Rect CalculateTargetsBoundingBox()
  {
    float minX = Mathf.Infinity;
    float maxX = Mathf.NegativeInfinity;
    float minY = Mathf.Infinity;
    float maxY = Mathf.NegativeInfinity;

    foreach (Transform target in targets)
    {
      Vector3 position = target.position;

      minX = Mathf.Min(minX, position.x);
      minY = Mathf.Min(minY, position.y);
      maxX = Mathf.Max(maxX, position.x);
      maxY = Mathf.Max(maxY, position.y);
    }

    return Rect.MinMaxRect(minX - boundingBoxPadding, maxY + boundingBoxPadding, maxX + boundingBoxPadding, minY - boundingBoxPadding);
  }

  float CalculateOrthographicSize(Rect boundingBox)
  {
    float orthographicSize = Camera.main.orthographicSize;
    Vector3 topRight = new Vector3(boundingBox.x + boundingBox.width, boundingBox.y, 0f);
    Vector3 topRightAsViewport = Camera.main.WorldToViewportPoint(topRight);

    if (topRightAsViewport.x >= topRightAsViewport.y)
      orthographicSize = Mathf.Abs(boundingBox.width) / Camera.main.aspect / 2f;
    else
      orthographicSize = Mathf.Abs(boundingBox.height) / 2f;

    return Mathf.Clamp(orthographicSize, minimumOrthographicSize, Mathf.Infinity);
  }
  public void SetLinePoint(Line l)
  {
    GameManager.Instance.SwitchPlayer();
  }
}
