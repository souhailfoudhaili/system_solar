using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public Transform earth;
    public Transform mars;
    public Transform moon;

    public float earthRotationSpeed = 50f;
    public float marsRotationSpeed = 50f;
    public float moonRotationSpeed = 30f;

    void Update()
    {
        // Earth's rotation around its own axis
        earth.Rotate(Vector3.up, earthRotationSpeed * Time.deltaTime);

        // Mars and Moon orbiting around Earth
        mars.position = Quaternion.Euler(0, earthRotationSpeed * Time.deltaTime, 0) * (mars.position - earth.position) + earth.position;
        moon.position = Quaternion.Euler(0, earthRotationSpeed * Time.deltaTime, 0) * (moon.position - earth.position) + earth.position;

        // Moon orbiting around Mars
        moon.position = Quaternion.Euler(0, marsRotationSpeed * Time.deltaTime, 0) * (moon.position - mars.position) + mars.position;

        // Mars's rotation around its own axis
        mars.Rotate(Vector3.up, marsRotationSpeed * Time.deltaTime);
    }
}