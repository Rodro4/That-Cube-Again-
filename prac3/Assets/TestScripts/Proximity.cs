using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Proximity : MonoBehaviour
{
    public TextMeshProUGUI proximityText;

    void Update()
    {
        InputSystem.EnableDevice(ProximitySensor.current);
        proximityText.text = ProximitySensor.current.distance.ReadValue().ToString();
    }
}
