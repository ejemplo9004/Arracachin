using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemigo : MonoBehaviour
{
    public Estados estado;
    public bool vivo = true;
    public float distanciaSeguir;
    public float distanciaAtacar;

    NavMeshAgent agente;
    float distanciaJugador;
    float frecuencia = 1;
    float sqrDistanciaSeguir;
    float sqrDistanciaAtacar;

    private void Awake()
	{
        agente = GetComponent<NavMeshAgent>();
        sqrDistanciaAtacar = distanciaAtacar * distanciaAtacar;
        sqrDistanciaSeguir = distanciaSeguir * distanciaSeguir;
	}

	// Start is called before the first frame update
	IEnumerator Start()
    {
		while (vivo)
		{
            CalcularDistancia();
            yield return new WaitForSeconds(frecuencia);
			switch (estado)
			{
				case Estados.idle:
                    EstadoIdle();
					break;
				case Estados.seguir:
                    EstadoSeguir();
					break;
				case Estados.atacar:
                    EstadoAtacar();
					break;
				case Estados.muerto:
                    EstadoMuerto();
					break;
				default:
					break;
			}
		}
    }

    void EstadoIdle()
	{
        frecuencia = 1;
		if (distanciaJugador < sqrDistanciaSeguir)
		{
            agente.SetDestination(Jugador.singleton.transform.position);
            CambiarEstado(Estados.seguir);
		}
    }
    void EstadoAtacar()
    {
        frecuencia = .3f;
        if (distanciaJugador > sqrDistanciaAtacar + 1)
        {
            agente.SetDestination(Jugador.singleton.transform.position);
            CambiarEstado(Estados.seguir);
        }
    }
    void EstadoSeguir()
    {
        frecuencia = 0.2f;
        agente.SetDestination(Jugador.singleton.transform.position);
        if (distanciaJugador < sqrDistanciaAtacar)
        {
            CambiarEstado(Estados.atacar);
        }
    }
    void EstadoMuerto()
    {
        frecuencia = 5;
    }

    void CambiarEstado(Estados nuevoEstado)
	{
		switch (nuevoEstado)
		{
			case Estados.idle:
				break;
			case Estados.seguir:
				break;
			case Estados.atacar:
                agente.SetDestination(transform.position);
                break;
			case Estados.muerto:
				break;
			default:
				break;
		}
		estado = nuevoEstado;
	}

    void CalcularDistancia()
	{
        distanciaJugador = (Jugador.singleton.transform.position - transform.position).sqrMagnitude;
	}

	private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaSeguir);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtacar);
    }
}

[System.Serializable]
public enum Estados
{
    idle = 0,
    seguir = 1,
    atacar = 2,
    muerto = 3
}
