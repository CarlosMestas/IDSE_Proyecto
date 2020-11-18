using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image Vida;
    
    float hp, maxHp=100f;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        Vida.transform.localScale = new Vector2(hp / maxHp, 1);
    }
}
