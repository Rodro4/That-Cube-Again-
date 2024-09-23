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
                Debug.Log("La batería está cargando.");
                playerMovement.canMove = true;
                break;
            case "Discharging":
                Debug.Log("La batería está descargando.");
                playerMovement.canMove = false;
                playerMovement.StopMoving();
                break;
            case "NotCharging":
                Debug.Log("La batería no está cargando.");
                playerMovement.canMove = false;
                playerMovement.StopMoving();
                break;
            case "Full":
                Debug.Log("La batería está completamente cargada.");
                playerMovement.canMove = true;
                break;
        }
    }
}
