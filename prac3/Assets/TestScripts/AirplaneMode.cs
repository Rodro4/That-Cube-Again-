using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AirplaneMode : MonoBehaviour
{
    public TextMeshProUGUI airplaneModeText;
    public void CheckAirplaneMode()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
        AndroidJavaClass globalSettings = new AndroidJavaClass("android.provider.Settings$Global");
        string modoAvion = globalSettings.CallStatic<string>("getString", contentResolver, "airplane_mode_on");

        if (modoAvion == "1") // Si es "1", el modo avi�n est� activado.
        {
            Debug.Log("Modo avi�n est� activado.");
            airplaneModeText.text = "Active";
        }
        else
        {
            Debug.Log("Modo avi�n no est� activado.");
            airplaneModeText.text = "NotActive";
        }
    }
}
