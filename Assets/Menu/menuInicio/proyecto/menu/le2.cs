using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class le2 : MonoBehaviour
{
    public void Empe()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Cerr()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
