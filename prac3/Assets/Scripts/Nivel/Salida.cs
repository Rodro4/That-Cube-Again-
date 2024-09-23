using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Salida : MonoBehaviour
{
    float distanciaMinima = 0.001f;
    float velocidadArrastre = 2f;
    float rotationSpeed = 500f;

    private Rigidbody2D jugadorRigidbody;
    //private PlayerMovement playerMovement;

    public ControladorEscena controladorEscena;

    [SerializeField] private AudioClip warp;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        GameObject gyroscopeLevel = GameObject.FindWithTag("GyroscopeLevel");
        if (gyroscopeLevel != null)
        {
            gyroscopeLevel.SetActive(false);
        }

        jugadorRigidbody = collision.GetComponent<Rigidbody2D>();
        jugadorRigidbody.velocity = new Vector2(0, 0);
        //playerMovement = collision.GetComponent<PlayerMovement>();
        StartCoroutine(ArrastrarJugador(collision.transform));
    }

    private IEnumerator ArrastrarJugador(Transform jugadorTransform)
    {
        ControladorSonido.Instance.EjecutarSonido(warp);

        //playerMovement.canMove = false;
        //jugadorRigidbody.gravityScale = 0f;
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

        //string scene = controladorEscena.GetSceneName();
        //PlayerPrefs.SetInt(scene, 1);
        controladorEscena.NextLevel();

        jugadorRigidbody.freezeRotation = true;
        jugadorRigidbody.bodyType = RigidbodyType2D.Dynamic;
        //jugadorRigidbody.gravityScale = 2.5f;
        //playerMovement.canMove = true;

        yield break;
    }
}