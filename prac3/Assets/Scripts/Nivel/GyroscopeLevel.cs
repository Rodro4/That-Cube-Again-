using UnityEngine;

public class GyroscopeLevel : MonoBehaviour
{
    public float moveSpeed = 5f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    void Update()
    {
        Vector3 gyroInput = -Input.gyro.gravity;

        Vector2 moveVector = new Vector2(-gyroInput.x, -gyroInput.y) * moveSpeed * Time.deltaTime;

        player.transform.Translate(moveVector);
    }
}
