using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AmbientLight : MonoBehaviour
{
    public TextMeshProUGUI ambientLight;

    void Update()
    {
        InputSystem.EnableDevice(LightSensor.current);
        var light = LightSensor.current.lightLevel.ReadValue();
        ambientLight.text = light.ToString();
    }
}