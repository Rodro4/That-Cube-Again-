using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class AccelerometerLevel : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int selectionPosition;
    public Vector3Int selectionSize;
    public Vector3Int newDestination;

    private bool firstTime = false;

    void Update()
    {
        InputSystem.EnableDevice(LinearAccelerationSensor.current);
        var linearAcceleration = LinearAccelerationSensor.current.acceleration.ReadValue();

        if (linearAcceleration.x > 4 && linearAcceleration.y < 3 && linearAcceleration.z < 3 && !firstTime)
        {
            firstTime = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            MoveTilemapSelectionToDestination();
        }
    }

    void MoveTilemapSelectionToDestination()
    {
        BoundsInt selectionBounds = new BoundsInt(selectionPosition, selectionSize);

        TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

        tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSize.x * selectionSize.y * selectionSize.z]);

        tilemap.SetTilesBlock(new BoundsInt(newDestination, selectionSize), selectedTiles);
    }
}
