using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMace : MonoBehaviour
{

    public float demage;
    public float demageTime;
    private float counter;
    private bool hasHit;
   
    
    void Start()
    {

    }

    void Update()
    {
        if(hasHit){
            counter += Time.deltaTime;
            if (counter > demageTime)
            {
                counter = 0;
                hasHit = false;
            }
        }

    }

   void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Player")
         {
            if (!hasHit)
            {
                PlayerLife.life -= demage;
                hasHit = true;
            }
            
        }
       
    }

}
