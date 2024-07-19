using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SigilHandler : MonoBehaviour, IPointerEnterHandler
{
    public Material litSigil;
    private Material defaultSigil;
    private Image image;
    public bool isConnected = false;
    bool isReady = false;

    MoveUIToTarget moveUI;

    void Start(){
        moveUI = GetComponent<MoveUIToTarget>();
        image = GetComponent<Image>();
        defaultSigil = image.material;
        Invoke("readyHitbox",0.15f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isConnected && isReady && !SpellCastingManager.instance.sigilLocked){
            //sigil connected
            isConnected = true;
            image.material = litSigil;
            
        }
    }

    void readyHitbox(){
        isReady = true;
    }


}
