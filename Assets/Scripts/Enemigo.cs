using UnityEngine;

public class Enemigo : MonoBehaviour
{
    int capaJugador;                                                                    //Variable para guardar el ID de la capa jugador

                                                          //Variable para saber si el enemigo está muerto
                                                                    //Referencia al Animador

    private void Start()
    {
        capaJugador = LayerMask.NameToLayer("Player");                                 //Obtenemos el ID de la capa

      			                    //Guardamos el ID de muerto en el animador
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == capaJugador)                                  //Chocamos contra el jugador
        {
            if (transform.position.y + 1.3f < collision.transform.position.y)           //Si el jugador está por encima, el enemigo muere
            {

                //Destroy(gameObject, 0.32f);                                             //Destruimos el objeto enemigo tras la animación
            }
        }
    }
}
