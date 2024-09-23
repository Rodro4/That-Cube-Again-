using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VolumeLevel : MonoBehaviour
{
    private AndroidJavaObject audioManager;

    private int previousVolume;

    public Tilemap tilemap;
    public Vector3Int[] originPosition;
    public Vector3Int[] destinationPosition;
    public Vector3Int selectionSizeH;
    public Vector3Int selectionSizeV;

    public int contadorExterno = 0;

    void Start()
    {
        try
        {
            using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (AndroidJavaObject context = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            {
                audioManager = context.Call<AndroidJavaObject>("getSystemService", "audio");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al obtener AudioManager de Android: " + e.Message);
        }
        previousVolume = audioManager.Call<int>("getStreamVolume", 3);
    }

    //public int volumen = 0;

    void Update()
    {
        if (audioManager != null)
        {
        int currentVolume = audioManager.Call<int>("getStreamVolume", 3);

        if (currentVolume > previousVolume)
        //if (volumen == 1)
        {
            //Arriba
            if (contadorExterno != 3)
            {
                Vector3Int destiny = destinationPosition[contadorExterno];
                Vector3Int origin = originPosition[contadorExterno];
                MoveHorizontal(destiny, origin);
                destiny = destinationPosition[contadorExterno + 3];
                origin = originPosition[contadorExterno + 3];
                MoveVertical(destiny, origin);
                contadorExterno++;
            }
        }
        else if (currentVolume < previousVolume)
        //else if (volumen == 2)
        {
            //Abajo
            if (contadorExterno != 0)
            {
                contadorExterno--;
                Vector3Int destiny = destinationPosition[contadorExterno];
                Vector3Int origin = originPosition[contadorExterno];
                MoveHorizontal(origin, destiny);
                destiny = destinationPosition[contadorExterno + 3];
                origin = originPosition[contadorExterno + 3];
                MoveVertical(origin, destiny);
            }
        }

        previousVolume = currentVolume;
        //volumen = 0;
        }
    }

    void MoveHorizontal(Vector3Int destiny, Vector3Int origin)
    {
        BoundsInt selectionBounds = new BoundsInt(origin, selectionSizeH);

        TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

        tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSizeH.x * selectionSizeH.y * selectionSizeH.z]);

        tilemap.SetTilesBlock(new BoundsInt(destiny, selectionSizeH), selectedTiles);
    }
    
    void MoveVertical(Vector3Int destiny, Vector3Int origin)
    {
        BoundsInt selectionBounds = new BoundsInt(origin, selectionSizeV);

        TileBase[] selectedTiles = tilemap.GetTilesBlock(selectionBounds).ToArray();

        tilemap.SetTilesBlock(selectionBounds, new TileBase[selectionSizeV.x * selectionSizeV.y * selectionSizeV.z]);

        tilemap.SetTilesBlock(new BoundsInt(destiny, selectionSizeV), selectedTiles);
    }
}