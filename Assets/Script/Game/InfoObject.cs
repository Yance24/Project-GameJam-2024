using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoObject : MonoBehaviour
{
    public float distance;
    public GameObject infoObj;
    Transform player;

    bool isSpawned = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        infoObj.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isSpawned && Vector2.Distance(player.position,transform.position) <= distance){
            isSpawned = true;
            infoObj.SetActive(true);
        }

        if(isSpawned && Vector2.Distance(player.position,transform.position) > distance){
            isSpawned = false;
            infoObj.SetActive(false);
        }
    }
}
