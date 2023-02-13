using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bala : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * velocidad;
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Enemigo"))
		{
			Destroy(gameObject);
			Destroy(collision.collider.transform.gameObject);
		}
	}
}
