using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryLevel : MonoBehaviour
{
    private string batteryStatusText;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        batteryStatusText = SystemInfo.batteryStatus.ToString();
        DebugBatteryStatus(batteryStatusText);
    }

    void DebugBatteryStatus(string status)
    {
        switch (status)
        {
            case "Charging":
                Debug.Log("La bater�a est� cargando.");
                playerMovement.canMove = true;
                break;
            case "Discharging":
                Debug.Log("La bater�a est� descargando.");
                playerMovement.canMove = false;
                playerMovement.StopMoving();
                break;
            case "NotCharging":
                Debug.Log("La bater�a no est� cargando.");
                playerMovement.canMove = false;
                playerMovement.StopMoving();
                break;
            case "Full":
                Debug.Log("La bater�a est� completamente cargada.");
                playerMovement.canMove = true;
                break;
        }
    }
}
