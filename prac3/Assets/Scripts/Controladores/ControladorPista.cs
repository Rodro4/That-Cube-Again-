using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPista : MonoBehaviour
{
    public void MostrarSolucion()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

}
