using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    public Material material1, material2, material3, material4;
    public Renderer rend1, rend2;
    

    float duration = 1f;
    public void newGame()
    {

        // gameObject.GetComponent<AudioSource>().Play(); 
        Debug.Log("new");
        SceneManager.LoadScene("Main");
        
    }

    public void exitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void newGameActivate()
    {

        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend1.material.Lerp(material1, material2, lerp); 
    }
    
    public void exitGameActivate()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend1.material.Lerp(material3, material2, lerp);
    }

}
