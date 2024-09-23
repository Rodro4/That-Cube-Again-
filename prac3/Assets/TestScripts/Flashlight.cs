using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Texto para mostrar el estado de la linterna
    public TextMeshProUGUI estadoLinternaTexto;

    // Método para actualizar el estado de la linterna
    public void ActualizarEstadoLinterna()
    {
        // Verificar si la linterna está encendida
        bool linternaEncendida = AndroidNativeFunctions.VerificarLinterna();

        // Actualizar el texto con el estado de la linterna
        if (linternaEncendida)
        {
            estadoLinternaTexto.text = "Linterna: Encendida";
        }
        else
        {
            estadoLinternaTexto.text = "Linterna: Apagada";
        }
    }
}

public static class AndroidNativeFunctions
{
    // Método para verificar el estado de la linterna en Android
    public static bool VerificarLinterna()
    {
        // Llama a la función nativa de Android para verificar el estado de la linterna
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.camera2.CameraManager");
        AndroidJavaObject cameraManager = context.Call<AndroidJavaObject>("getSystemService", "camera");
        string[] cameraIds = cameraManager.Call<string[]>("getCameraIdList");

        foreach (string cameraId in cameraIds)
        {
            bool flashAvailable = cameraManager.Call<bool>("hasFlash", cameraId);
            if (flashAvailable)
            {
                return true;
            }
        }

        return false;
    }
}
