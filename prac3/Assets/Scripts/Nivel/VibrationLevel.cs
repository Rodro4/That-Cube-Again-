using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationLevel : MonoBehaviour
{
    public float vibrationDuration = 0.2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

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
    }
}
