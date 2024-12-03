/*
    Inicial [26/11/2024]
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // Movimiento continuo hacia adelante
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Rotación más suave
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        // Rotar gradualmente
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}