using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadTestMainMenu()
    {
        SceneManager.LoadScene("TestMainMenu");
    }

    public void LoadBateryStatus()
    {
        SceneManager.LoadScene("BateryStatus");
    }
    
    public void LoadAirplaneMode()
    {
        SceneManager.LoadScene("AirplaneMode");
    }

    public void LoadGyroscope()
    {
        SceneManager.LoadScene("Gyroscope");
    }
    
    public void LoadDetectDecibels()
    {
        SceneManager.LoadScene("DetectDecibels");
    }
    
    public void LoadAmbientLight()
    {
        SceneManager.LoadScene("AmbientLight");
    }
    
    public void LoadBluetooth()
    {
        SceneManager.LoadScene("Bluetooth");
    }

    public void LoadAccelerometer()
    {
        SceneManager.LoadScene("Accelerometer");
    }
    
    public void LoadFlashlight()
    {
        SceneManager.LoadScene("Flashlight");
    }

    public void LoadVibration()
    {
        SceneManager.LoadScene("Vibration");
    } 
    
    public void LoadTactileSensor()
    {
        SceneManager.LoadScene("TactileSensor");
    }
    
    public void LoadVolumeButton()
    {
        SceneManager.LoadScene("VolumeButton");
    }
    
    public void LoadProximity()
    {
        SceneManager.LoadScene("Proximity");
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
