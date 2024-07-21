using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource hoverSoundSource;
    public AudioSource clickSoundSource;

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene-Main-Hub");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
