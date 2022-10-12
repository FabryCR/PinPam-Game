using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }

    //Botones
    public void Load2Players()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Stop("Menu");
    }

    public void LoadVSCPU()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(2);
        FindObjectOfType<AudioManager>().Stop("Menu");
    }

    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
        Debug.Log("SALIR");
    }

}
