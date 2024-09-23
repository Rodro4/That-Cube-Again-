using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneLevel : MonoBehaviour
{
    private Rigidbody2D rb;

    public static string modoAvion;

    private void Start()
    {
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject>("getContentResolver");
        AndroidJavaClass globalSettings = new AndroidJavaClass("android.provider.Settings$Global");
        modoAvion = globalSettings.CallStatic<string>("getString", contentResolver, "airplane_mode_on");

        if (modoAvion == "1") // Si es "1", el modo avión está activado.
        {
            rb.gravityScale = 0f;
            CheckGround.onGround = true;

            if (!JumpButton.jumpIsPressed)
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            rb.gravityScale = 2.5f;
        }
    }
}
