 using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovimiento : MonoBehaviour
{
    public float vel = 5.0f;
    public float correrVel = 8.0f;
    public float fuerzaSalto = 600f;

    private bool jump;
    private bool movement = true;

    public Transform checkSuelo;
    public LayerMask capaSuelo;


    bool enSuelo;
    bool correr; 
    bool dobleSalto;

    int contador;
    public Text monedas;

    Rigidbody2D rb;
    Animator anim;
    Vector3 escalaPrin;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        escalaPrin = transform.localScale;
    }

    private void Update()
    {
        float h;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            correr = true;
        }
        else
        {
            correr = false;
        }
        if (correr)
        {
            h = Input.GetAxis("Horizontal") * correrVel;
        }
        else
        {
            h = Input.GetAxis("Horizontal") * vel;
        }
        if (!movement) h = 0;

        rb.velocity = new Vector2(h, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo)
            {
                rb.AddForce(Vector2.up * fuerzaSalto);
                anim.SetTrigger("Saltar");
            }
            else if (dobleSalto)
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * fuerzaSalto);
                anim.SetTrigger("Saltar");
                dobleSalto = false;
            }

        }

        if (rb.velocity.x > 0)
        {
            transform.localScale = escalaPrin;
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-escalaPrin.x, escalaPrin.y, escalaPrin.z);
        }

        //Animaciones
        if (h != 0)
        {
            anim.SetBool("Andar", true);
        }
        else
        {
            anim.SetBool("Andar", false);
        }
        anim.SetBool("Correr", correr);
        anim.SetBool("enSuelo", enSuelo);

        //Doble salto

        if (enSuelo)
        {
            dobleSalto = true;
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(checkSuelo.position, 0.1f, capaSuelo);
    }

    public void EnemyKnockBack(float enemyPosX)
    {
        jump = true;

        float side = Mathf.Sign(enemyPosX - transform.position.x);
        rb.AddForce(Vector2.left * side * fuerzaSalto, ForceMode2D.Impulse);
        movement = false;
        Invoke("EnableMovement", 0.7f);
    }

    void EnableMovement()
    {
        movement = true;
    }

}
