using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SigilHandler : MonoBehaviour, IPointerEnterHandler
{
    public bool isConnected = false;
    bool isReady = false;

    MoveUIToTarget moveUI;

    void Start(){
        moveUI = GetComponent<MoveUIToTarget>();
        Invoke("readyHitbox",0.15f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isConnected && isReady && !SpellCastingManager.instance.sigilLocked){
            isConnected = true;
            Debug.Log("connect!");
        }
    }

    void readyHitbox(){
        isReady = true;
    }


}
