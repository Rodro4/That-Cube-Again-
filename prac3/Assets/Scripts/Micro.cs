using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Micro : MonoBehaviour
{
    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;
    private string _microphone;

    void Start()
    {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;

        // Obt�n el nombre del micr�fono disponible (puedes ajustar esto seg�n tu configuraci�n)
        _microphone = Microphone.devices.Length > 0 ? Microphone.devices[0] : null;


        // Inicia la grabaci�n del micr�fono
        if (_microphone != null)
            GetComponent<AudioSource>().clip = Microphone.Start(_microphone, true, 10, (int)_fSample);
    }

    void Update()
    {
        AnalyzeSound();

        Debug.Log("RMS: " + rmsVal.ToString("F2"));
        Debug.Log(dbVal.ToString("F1") + " dB");
        Debug.Log(pitchVal.ToString("F0") + " Hz");
    }

    void AnalyzeSound()
    {
        if (_microphone == null)
            return;

        AudioSource audioSource = GetComponent<AudioSource>();

        // Obt�n datos del micr�fono en tiempo real
        audioSource.clip.GetData(_samples, audioSource.timeSamples);

        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i];
        }
        rmsVal = Mathf.Sqrt(sum / QSamples);
        dbVal = 20 * Mathf.Log10(rmsVal / RefValue);
        if (dbVal < -160) dbVal = -160;

        // Obt�n el espectro de frecuencia del micr�fono
        audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        {
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i;
        }
        float freqN = maxN;
        if (maxN > 0 && maxN < QSamples - 1)
        {
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchVal = freqN * (_fSample / 2) / QSamples;
    }


    void OnDisable()
    {
        // Det�n la grabaci�n del micr�fono al deshabilitar el script
        if (_microphone != null)
            Microphone.End(_microphone);
    }
}
