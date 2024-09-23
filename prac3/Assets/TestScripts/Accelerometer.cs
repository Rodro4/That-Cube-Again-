using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AccelerometerSensor : MonoBehaviour
{
    public TextMeshProUGUI accelerometerSensorText;
    public TextMeshProUGUI gravitySensorText;
    public TextMeshProUGUI linearAccelerationSensorText;

    public float velocidad = 5.0f;

    void Update()
    {
        InputSystem.EnableDevice(Accelerometer.current);
        var acceleration = Accelerometer.current.acceleration.ReadValue();
        accelerometerSensorText.text = acceleration.ToString();

        InputSystem.EnableDevice(LinearAccelerationSensor.current);
        var linearAcceleration = LinearAccelerationSensor.current.acceleration.ReadValue();
        linearAccelerationSensorText.text = linearAcceleration.ToString();

        InputSystem.EnableDevice(GravitySensor.current);
        var gravity = GravitySensor.current.gravity.ReadValue();
        gravitySensorText.text = gravity.ToString();




        // Obtener los valores del aceler�metro en cada eje
        float accX = Input.acceleration.x;
        float accY = Input.acceleration.y;

        // Calcular la nueva posici�n del objeto
        Vector3 nuevaPosicion = transform.position + new Vector3(accX, accY, 0) * velocidad * Time.deltaTime;

        // Limitar la posici�n del objeto al �rea visible (puedes ajustar estos l�mites seg�n tus necesidades)
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, -5f, 5f);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, -5f, 5f);

        // Aplicar la nueva posici�n al objeto
        transform.position = nuevaPosicion;
    }
}
