using UnityEngine;

public class TactileSensor : MonoBehaviour
{
    public float velocidadMovimiento = 5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 posicionTocada = Camera.main.ScreenToWorldPoint(touch.position);
            posicionTocada.z = 0f;

            transform.position = Vector3.Lerp(transform.position, posicionTocada, velocidadMovimiento * Time.deltaTime);
        }
    }
}
