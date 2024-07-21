using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManage : MonoBehaviour
{
    public void restart(){
        SceneManager.LoadScene("Scene-Main-Hub");
    }

    public void exit(){
        Application.Quit();
    }
}
