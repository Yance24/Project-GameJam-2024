using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManage : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseUI;

    void Start(){
        pauseButton.SetActive(true);
        pauseUI.SetActive(false);
    }

    public void pauseButtonPressed(){
        pauseButton.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void resume(){
        pauseButton.SetActive(true);
        pauseUI.SetActive(false);
    }

    public void exit(){
        SceneManager.LoadScene("TitleScreen");
    }
}
