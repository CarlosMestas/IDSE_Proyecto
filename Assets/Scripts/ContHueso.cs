using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContHueso : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            CoinWindow.SetCoinCount(1);
            Destroy(gameObject);
        }
    }
}
