using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MauseAudio : MonoBehaviour
{
    /*Sound*/
    public AudioClip MySound;
    
    /*OnMouseOver*/
    void OnMouseOver()
    {
        Debug.Log("Play_Audio");
        GetComponent<AudioSource>().Play();
    }
}



