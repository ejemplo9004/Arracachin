using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float velocidadGiro = 90;
    public Transform target;
    public Joystick joystick;
    public float smootMov = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, smootMov * Time.deltaTime);
        transform.Rotate(Vector3.up * velocidadGiro * Time.deltaTime * joystick.Horizontal);
    }
}
