using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nombre : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI textoMeshPro = GetComponent<TextMeshProUGUI>();
        string name = PlayerPrefs.GetString("Name", "");
        textoMeshPro.text = ("Bienvenido " + name);
    }
}
