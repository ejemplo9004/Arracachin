using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    public static ControlJuego singleton;
	public MapGenerator mapa;
	public Poblador poblador;
	public GameObject uiCarga;
	

	private void Awake()
	{
        singleton = this;
	}

	IEnumerator Start()
	{
		yield return new WaitUntil(() => mapa.mapaGenerado);
		yield return new WaitUntil(() => poblador.poblado);
		uiCarga.SetActive(false);

	}
}
