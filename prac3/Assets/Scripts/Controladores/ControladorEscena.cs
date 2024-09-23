using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorEscena : MonoBehaviour
{
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NextLevel()
    {
        string scene = GetSceneName();
        PlayerPrefs.SetInt(scene, 1);

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }

    public static string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
