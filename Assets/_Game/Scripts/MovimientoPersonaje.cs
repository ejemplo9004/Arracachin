using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 3;
    public Joystick joystick;
    public Transform pivoteCamara;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(joystick.Horizontal) + Mathf.Abs(joystick.Vertical) > 0.02f)
		{
            transform.forward = pivoteCamara.forward;
            transform.Translate((Vector3.forward * (Input.GetAxis("Vertical") + joystick.Vertical) + Vector3.right * (Input.GetAxis("Horizontal") + joystick.Horizontal)) * velocidad * Time.deltaTime);
        }
        
    }
}
