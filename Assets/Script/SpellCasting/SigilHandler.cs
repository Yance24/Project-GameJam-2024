using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SigilHandler : MonoBehaviour, IPointerEnterHandler
{
    public Material litSigil;
    public int id;
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

    public RectTransform rectTransform(){
        return GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isConnected && isReady && !SpellCastingManager.instance.sigilLocked){
            //sigil connected
            isConnected = true;
            image.material = litSigil;
            SigilConnectSFX.instance.playSFX();
            SpellCastingManager.instance.addConnectedSigils(this);
        }
    }

    void readyHitbox(){
        isReady = true;
    }


}
