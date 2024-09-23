using UnityEngine;
using TMPro;

public class Bluetooth : MonoBehaviour
{
    public TextMeshProUGUI bluetoothStatus;

    public void CheckBluetooth()
    {
        using (AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        {
            using (var bluetoothManager = activity.Call<AndroidJavaObject>("getSystemService", "bluetooth"))
            {
                using (var bluetoothAdapter = bluetoothManager.Call<AndroidJavaObject>("getAdapter"))
                {
                    if (bluetoothAdapter != null)
                    {
                        bool isEnabled = bluetoothAdapter.Call<bool>("isEnabled");
                        Debug.Log("Estado del Bluetooth: " + (isEnabled ? "Activado" : "Desactivado"));
                        bluetoothStatus.text = isEnabled ? "Active" : "NotActive";
                    }
                    else
                    {
                        Debug.LogError("Adaptador de Bluetooth es nulo");
                        bluetoothStatus.text = "Error";
                    }
                }
            }
        }
    }
}
