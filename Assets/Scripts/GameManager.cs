using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	static GameManager current;

	int monedas;                           //Variable monedas

	void Awake()
	{
		//Si Game Manager ya tiene un valor y no es este...
		if (current != null && current != this)
		{
			//...destruimos y salimos. Solo puede haber un Game Manager
			Destroy(gameObject);
			return;
		}

		//Si no tenía valor el Game Manager, se lo ponemos
		current = this;

		//Objeto persistente (no le afecta el cambio de escenas)
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		//Iniciamos los valores de la partida
		InicioPartida();
	}

	public static void ActualizarMonedas()
	{
		//Si no hay Game Manager, salimos
		if (current == null)
			return;

		//Sumo una moneda y lo muestro en pantalla
		if (current.monedas == 99)
		{
			current.monedas = 0;
		}
		else
		{
			current.monedas += 1;
		}
		UIManager.ActualizarMonedasUI(current.monedas);
	}

	void InicioPartida()
	{
		//Valores de inicio de la partida
		current.monedas = 0;
		UIManager.ActualizarMonedasUI(current.monedas);
	}
}
