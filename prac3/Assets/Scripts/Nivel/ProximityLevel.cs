using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ProximityLevel : MonoBehaviour
{
    private string proximityText;

    public Tilemap tilemap;

    private const int numPlataformas = 2;

    public Vector3Int[] selectionPosition = new Vector3Int[numPlataformas];
    public Vector3Int[] newDestination = new Vector3Int[numPlataformas * 2];

    public Vector3Int selectionSize0;
    public Vector3Int selectionSize1;

    private float timeElapsed0 = 0f;
    private float timeElapsed1 = 0f;

    void Update()
    {
        InputSystem.EnableDevice(ProximitySensor.current);
        proximityText = ProximitySensor.current.distance.ReadValue().ToString();

        if (int.Parse(proximityText) < 3)
        {
            MoveTilesPositive0();
            MoveTilesPositive1();
        }
        else
        {
            MoveTilesNegative0();
            MoveTilesNegative1();
        }
    }

    // Pos 0
    void MoveTilesPositive0()
    {
        timeElapsed0 += Time.deltaTime;

        if (timeElapsed0 >= 1f)
        {
            BoundsInt selectionBounds = new BoundsInt(selectionPosition[0], selectionSize0);

            TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

            tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSize0.x * selectionSize0.y * selectionSize0.z]);

            float t = Mathf.Clamp01(Time.deltaTime);
            Vector3 currentPosition = Vector3.Lerp(selectionPosition[0], newDestination[0], t);

            tilemap.SetTilesBlock(new BoundsInt(Vector3Int.CeilToInt(currentPosition), selectionSize0), selectedTiles);
            selectionPosition[0] = Vector3Int.CeilToInt(currentPosition);

            timeElapsed0 = 0f;
        }
    }

    void MoveTilesNegative0()
    {
        timeElapsed0 += Time.deltaTime;

        if (timeElapsed0 >= 1f)
        {
            BoundsInt selectionBounds = new BoundsInt(selectionPosition[0], selectionSize0);

            TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

            tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSize0.x * selectionSize0.y * selectionSize0.z]);

            float t = Mathf.Clamp01(Time.deltaTime);
            Vector3 currentPosition = Vector3.Lerp(selectionPosition[0], newDestination[2], t);

            tilemap.SetTilesBlock(new BoundsInt(Vector3Int.FloorToInt(currentPosition), selectionSize0), selectedTiles);
            selectionPosition[0] = Vector3Int.FloorToInt(currentPosition);

            timeElapsed0 = 0f;
        }
    }

    // Pos 1
    void MoveTilesPositive1()
    {
        timeElapsed1 += Time.deltaTime;

        if (timeElapsed1 >= 1f)
        {
            BoundsInt selectionBounds = new BoundsInt(selectionPosition[1], selectionSize1);

            TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

            tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSize1.x * selectionSize1.y * selectionSize1.z]);

            float t = Mathf.Clamp01(Time.deltaTime);
            Vector3 currentPosition = Vector3.Lerp(selectionPosition[1], newDestination[1], t);

            tilemap.SetTilesBlock(new BoundsInt(Vector3Int.CeilToInt(currentPosition), selectionSize1), selectedTiles);
            selectionPosition[1] = Vector3Int.CeilToInt(currentPosition);

            timeElapsed1 = 0f;
        }
    }

    void MoveTilesNegative1()
    {
        timeElapsed1 += Time.deltaTime;

        if (timeElapsed1 >= 1f)
        {
            BoundsInt selectionBounds = new BoundsInt(selectionPosition[1], selectionSize1);

            TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

            tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSize1.x * selectionSize1.y * selectionSize1.z]);

            float t = Mathf.Clamp01(Time.deltaTime);
            Vector3 currentPosition = Vector3.Lerp(selectionPosition[1], newDestination[3], t);

            tilemap.SetTilesBlock(new BoundsInt(Vector3Int.FloorToInt(currentPosition), selectionSize1), selectedTiles);
            selectionPosition[1] = Vector3Int.FloorToInt(currentPosition);

            timeElapsed1 = 0f;
        }
    }
}