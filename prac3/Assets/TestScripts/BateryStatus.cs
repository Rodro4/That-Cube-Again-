using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryStatus : MonoBehaviour
{
    public TextMeshProUGUI batteryStatusText;

    public void CheckBateryStatus()
    {
        batteryStatusText.text = SystemInfo.batteryStatus.ToString();
        DebugBatteryStatus(batteryStatusText.text);
    }

    void DebugBatteryStatus(string status)
    {
        switch (status)
        {
            case "Charging":
                Debug.Log("La batería está cargando.");
                break;
            case "Discharging":
                Debug.Log("La batería está descargando.");
                break;
            case "NotCharging":
                Debug.Log("La batería no está cargando.");
                break;
            case "Full":
                Debug.Log("La batería está completamente cargada.");
                break;
            case "Unknown":
                Debug.Log("Estado de la batería desconocido.");
                break;
            default:
                Debug.LogError("Estado de la batería no reconocido.");
                break;
        }
    }
}
