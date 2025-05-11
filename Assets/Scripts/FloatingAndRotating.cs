using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAndRotating : MonoBehaviour
{
    public float rotationSpeed = 90f; 
    public float floatHeight = 0.5f; 
    public float floatSpeed = 1f; 

    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        float newY = Mathf.Sin(Time.time * floatSpeed) * floatHeight + startPosition.y;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
