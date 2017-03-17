using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float m_maxRotationSpeed = 10;

    private Vector3 m_rotationSpeed;
    void Start()
    {
        var initialRotation = UnityEngine.Random.insideUnitSphere * 360;
        transform.rotation = Quaternion.Euler(initialRotation);

        m_rotationSpeed = UnityEngine.Random.insideUnitSphere * m_maxRotationSpeed;
    }
    
    void Update()
    {
        transform.Rotate(m_rotationSpeed * Time.deltaTime);
    }
}
