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
                Debug.Log("La bater�a est� cargando.");
                break;
            case "Discharging":
                Debug.Log("La bater�a est� descargando.");
                break;
            case "NotCharging":
                Debug.Log("La bater�a no est� cargando.");
                break;
            case "Full":
                Debug.Log("La bater�a est� completamente cargada.");
                break;
            case "Unknown":
                Debug.Log("Estado de la bater�a desconocido.");
                break;
            default:
                Debug.LogError("Estado de la bater�a no reconocido.");
                break;
        }
    }
}
