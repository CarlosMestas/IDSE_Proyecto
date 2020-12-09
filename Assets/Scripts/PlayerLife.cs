using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{

    public static float life;
    private Slider lifebar;

    void Start()
    {
        life = 100;
        lifebar = GameObject.FindGameObjectWithTag("lifebar").GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.value = life;

    }
}
