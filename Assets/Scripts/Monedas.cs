﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monedas : MonoBehaviour
{
	int playerLayer;                                                //Variable para guardar el ID de la capa del jugador

	void Start()
	{
		playerLayer = LayerMask.NameToLayer("Player");             //Obtenemos el ID de la capa del jugador
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != playerLayer)              //Si la capa del objeto que colisiona no es PlayerLayer, salimos
			return;

		GameManager.ActualizarMonedas();                            //Actualizamos las monedas
		gameObject.SetActive(false);                                //Destruimos el objeto
	}
}
