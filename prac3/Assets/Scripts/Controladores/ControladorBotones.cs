using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBotones : MonoBehaviour
{
    public Button[] levels = new Button[12];
    //public Button level2;
    //public Button level3;

    void Start()
    {
        for (int i = 1; i < levels.Length; i++)
        {
            string level = "Level" + i;
            Debug.Log(level);
            // Verifica si la condición está cumplida
            bool levelStatus = PlayerPrefs.GetInt(level, 0) == 1;

            // Activa o desactiva la interactividad del botón según la condición
            levels[i].interactable = levelStatus;
            Debug.Log(levels[i]);
        }
        //bool level1Status = PlayerPrefs.GetInt("Level1", 0) == 1;
        //bool level2Status = PlayerPrefs.GetInt("Level2", 0) == 1;


        //level2.interactable = level1Status;
        //level3.interactable = level2Status;
    }
}