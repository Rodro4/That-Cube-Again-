using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    public static ControladorSonido Instance;
    public AudioSource[] audioSources;

    [HideInInspector] public AudioSource soundsAudioSource;
    [HideInInspector] public AudioSource musicAudioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSources = GetComponents<AudioSource>();
        soundsAudioSource = audioSources[0];
        musicAudioSource = audioSources[1];

        EffectsVolume();
        MusicVolume();
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        soundsAudioSource.PlayOneShot(sonido);
    }

    public void EffectsVolume()
    {
        soundsAudioSource.volume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
    }

    public void MusicVolume()
    {
        musicAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
}