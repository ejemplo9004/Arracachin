using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform referencia;
    public GameObject bala;
    public float tiempoCarga = 0.5f;
    public bool cargando;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
            Disparar();
		}
    }

    public void Disparar()
	{
		if (!cargando)
		{
            Instantiate(bala, referencia.position, referencia.rotation);
            StartCoroutine(Cargando());
		}
	}

    IEnumerator Cargando()
	{
        cargando = true;
		for (int i = 0; i < 10; i++)
		{
            yield return new WaitForSeconds(tiempoCarga / 10f);
		}
        cargando = false;
	}
}
