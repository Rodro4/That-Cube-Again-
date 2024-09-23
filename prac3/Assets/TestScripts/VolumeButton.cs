using UnityEngine;
using TMPro;

public class VolumeButton : MonoBehaviour
{
    public TextMeshProUGUI texto;

    private AndroidJavaObject audioManager;

    void Start()
    {
        // Intenta obtener el AudioManager de Android
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
    }

    void Update()
    {
        // Verifica cambios en el volumen
        if (audioManager != null)
        {
            int currentVolume = audioManager.Call<int>("getStreamVolume", 3); // AudioManager.STREAM_MUSIC

            // Ajusta el c�digo seg�n la l�gica de tu aplicaci�n
            if (currentVolume > previousVolume)
            {
                MostrarTexto(currentVolume.ToString());
            }
            else if (currentVolume < previousVolume)
            {
                MostrarTexto(currentVolume.ToString());
            }

            previousVolume = currentVolume;
        }
    }

    private int previousVolume = 0;

    void MostrarTexto(string mensaje)
    {
        // Actualiza el texto en el objeto TextMeshPro
        texto.text = mensaje;

        // Puedes agregar cualquier otra l�gica aqu� seg�n tus necesidades
    }
}
