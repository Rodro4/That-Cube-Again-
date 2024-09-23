using UnityEngine;
using UnityEngine.InputSystem;

public class AmbientLightLevel : MonoBehaviour
{
    private int valorMinimo = 0;
    private int valorMaximo = 4000;

    void Update()
    {
        InputSystem.EnableDevice(LightSensor.current);
        var light = LightSensor.current.lightLevel.ReadValue();

        if (light > valorMaximo)
        {
            light = valorMaximo;
        }

        float escala = Map(light, valorMinimo, valorMaximo, 1.5f, 7f);

        transform.localScale = new Vector3(escala, escala, escala);
    }

    float Map(float valor, float rangoEntradaMin, float rangoEntradaMax, float rangoSalidaMin, float rangoSalidaMax)
    {
        return rangoSalidaMin + (valor - rangoEntradaMin) * (rangoSalidaMax - rangoSalidaMin) / (rangoEntradaMax - rangoEntradaMin);
    }
}