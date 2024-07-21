using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public float distance;
    public Transform target;
    public string SceneName;
    bool isChange = false;

    // Update is called once per frame
    void Update()
    {
        if(!isChange && Vector2.Distance(transform.position,target.position) < distance){
            SceneManager.LoadScene(SceneName);
            isChange = true;
        }
    }
}
