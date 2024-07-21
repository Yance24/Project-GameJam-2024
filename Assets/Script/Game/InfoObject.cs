using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoObject : MonoBehaviour
{
    public float distance;
    public GameObject infoObj;
    public RectTransform placeHolder;
    Transform player;

    bool isSpawned = false;
    RectTransform infoObjRect;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        infoObjRect = infoObj.GetComponent<RectTransform>();
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

        if(isSpawned){
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector2 localPosition;

            // Convert world position to local position
            RectTransformUtility.ScreenPointToLocalPointInRectangle(placeHolder, screenPosition, Camera.main, out localPosition);

            infoObjRect.localPosition = localPosition;
        }
    }
}
