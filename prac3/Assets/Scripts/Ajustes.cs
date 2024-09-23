//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class Ajustes : MonoBehaviour
//{
//    public Toggle redSkin;
//    public Toggle greenSkin;

//    public TMP_InputField textField;

//    private void Start()
//    {
//        int skinColor = PlayerPrefs.GetInt("SkinColor", 0);

//        // 1 -> Rojo
//        // 0 -> Verde
//        if (skinColor == 1)
//        {
//            redSkin.isOn = true;
//        }
//        else
//        {
//            greenSkin.isOn = true;
//        }

//        redSkin.onValueChanged.AddListener((value) => SaveSkin(value, 1));
//        greenSkin.onValueChanged.AddListener((value) => SaveSkin(value, 2));

//        string name = PlayerPrefs.GetString("Name", "");
//        textField.text = name;
//    }

//    private void SaveSkin(bool state, int buttonNumber)
//    {
//        if (state)
//        {
//            PlayerPrefs.SetInt("SkinColor", buttonNumber);
//            PlayerPrefs.Save();
//        }
//    }

//    public void OnConfirmButtonPressed()
//    {
//        string textToSave = textField.text;
//        PlayerPrefs.SetString("Name", textToSave);
//        PlayerPrefs.Save();
//    }
//}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour
{
    public Toggle redSkin;
    public Toggle greenSkin;

    public Slider effectsSlider;
    public Slider musicSlider;

    public TMP_InputField textField;

    private void Start()
    {
        int skinColor = PlayerPrefs.GetInt("SkinColor", 0);

        // 1 -> Rojo
        // 0 -> Verde
        if (skinColor == 1)
        {
            redSkin.isOn = true;
        }
        else
        {
            greenSkin.isOn = true;
        }

        redSkin.onValueChanged.AddListener((value) => SaveSkin(value, 1));
        greenSkin.onValueChanged.AddListener((value) => SaveSkin(value, 2));

        float effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        effectsSlider.value = effectsVolume;
        musicSlider.value = musicVolume;

        effectsSlider.onValueChanged.AddListener((value) => SaveVolume(value, "EffectsVolume"));
        musicSlider.onValueChanged.AddListener((value) => SaveVolume(value, "MusicVolume"));

        string name = PlayerPrefs.GetString("Name", "");
        textField.text = name;
    }

    private void SaveSkin(bool state, int buttonNumber)
    {
        if (state)
        {
            PlayerPrefs.SetInt("SkinColor", buttonNumber);
            PlayerPrefs.Save();
        }
    }

    public void OnConfirmButtonPressed()
    {
        string textToSave = textField.text;
        PlayerPrefs.SetString("Name", textToSave);
        PlayerPrefs.Save();
    }

    private void SaveVolume(float volume, string audioType)
    {
        PlayerPrefs.SetFloat(audioType, volume);
        PlayerPrefs.Save();

        ControladorSonido.Instance.EffectsVolume();
        ControladorSonido.Instance.MusicVolume();
    }
}