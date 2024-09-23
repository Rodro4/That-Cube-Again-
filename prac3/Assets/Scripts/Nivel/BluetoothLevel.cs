using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothLevel : MonoBehaviour
{
    private string bluetoothStatus;

    private Rigidbody2D jugadorRigidbody;

    float distanciaMinima = 0.001f;
    float velocidadArrastre = 2f;
    float rotationSpeed = 500f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))return;

        CheckBluetooth(collision);
    }

    public void CheckBluetooth(Collider2D collision)
    {
        using (AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        {
            using (var bluetoothManager = activity.Call<AndroidJavaObject>("getSystemService", "bluetooth"))
            {
                using (var bluetoothAdapter = bluetoothManager.Call<AndroidJavaObject>("getAdapter"))
                {
                    if (bluetoothAdapter != null)
                    {
                        bool isEnabled = bluetoothAdapter.Call<bool>("isEnabled");

                        if (isEnabled)
                        {
                            jugadorRigidbody = collision.GetComponent<Rigidbody2D>();
                            jugadorRigidbody.velocity = new Vector2(0, 0);
                            StartCoroutine(ArrastrarJugador(collision.transform));
                        }
                    }
                }
            }
        }
    }
    private IEnumerator ArrastrarJugador(Transform jugadorTransform)
    {
        jugadorRigidbody.bodyType = RigidbodyType2D.Kinematic;
        jugadorRigidbody.freezeRotation = false;

        while (Vector2.Distance(jugadorTransform.position, transform.position) > distanciaMinima)
        {
            jugadorTransform.position = Vector2.Lerp(jugadorTransform.position, transform.position, velocidadArrastre * Time.deltaTime);
            jugadorTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            yield return null;
        }

        while (!(jugadorTransform.eulerAngles.z > -10 && jugadorTransform.eulerAngles.z < 10))
        {
            jugadorTransform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            yield return null;
        }

        jugadorTransform.eulerAngles = Vector3.zero;

        jugadorTransform.position = new Vector2(0.5f, 4.5f);

        jugadorRigidbody.freezeRotation = true;
        jugadorRigidbody.bodyType = RigidbodyType2D.Dynamic;

        yield break;
    }
}
