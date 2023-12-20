using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f; // Rychlost pohybu
    public float forceMultiplier = 10f; // N�sobitel s�ly

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        // Z�sk�n� vstupu od hr��e
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Vytvo�en� vektoru pohybu na z�klad� vstupu
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Pohyb objektu na z�klad� vektoru pohybu
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * movementSpeed * Time.deltaTime);

        // Pou�it� s�ly pro pohyb (pro realisti�t�j�� efekt)
        Vector3 force = new Vector3(horizontalInput, 0f, verticalInput) * forceMultiplier;
        rb.AddForce(force);
    }
}
