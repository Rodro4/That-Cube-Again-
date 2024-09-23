using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TactileLevel : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float distanciaMinima = 0.5f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    Vector2 posicionTocada = Camera.main.ScreenToWorldPoint(touch.position);

        //    player.transform.position = Vector2.Lerp(player.transform.position, posicionTocada, velocidadMovimiento * Time.deltaTime);
        //}

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    Vector2 posicionTocada = Camera.main.ScreenToWorldPoint(touch.position);

        //    // Calcula la dirección del movimiento
        //    Vector2 direccionMovimiento = (posicionTocada - (Vector2)player.transform.position).normalized;

        //    // Mueve al jugador en la dirección calculada
        //    player.transform.position += new Vector3(direccionMovimiento.x, direccionMovimiento.y, 0f) * velocidadMovimiento * Time.deltaTime;
        //}

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 posicionTocada = Camera.main.ScreenToWorldPoint(touch.position);

            // Calcula la dirección del movimiento
            Vector2 direccionMovimiento = (posicionTocada - (Vector2)player.transform.position).normalized;

            // Calcula la distancia entre el dedo y el jugador
            float distancia = Vector2.Distance(posicionTocada, player.transform.position);

            // Mueve al jugador solo si la distancia es mayor que la distancia mínima
            if (distancia < distanciaMinima)
            {
                // Mueve al jugador en la dirección calculada
                player.transform.position += new Vector3(direccionMovimiento.x, direccionMovimiento.y, 0f) * velocidadMovimiento * Time.deltaTime;
            }
        }
    }
}
