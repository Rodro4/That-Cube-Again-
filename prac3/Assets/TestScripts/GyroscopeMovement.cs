using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GyroscopeMovement : MonoBehaviour
{
    private float moveSpeed = 10f;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        Vector3 gyroInput = -Input.gyro.gravity;

        Vector2 moveVector = new Vector2(-gyroInput.x, -gyroInput.y) * moveSpeed * Time.deltaTime;

        transform.Translate(moveVector);
    }
}