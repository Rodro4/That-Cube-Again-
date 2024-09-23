using System.Collections;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    public float vibrationDuration = 0.2f;

    public void OnButtonClick()
    {
        StartCoroutine(VibrateDevice());
    }

    IEnumerator VibrateDevice()
    {
        if (SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
            yield return new WaitForSeconds(vibrationDuration);
            Handheld.Vibrate();
        }
        else
        {
            Debug.LogWarning("El dispositivo no soporta vibración.");
        }
    }
}
