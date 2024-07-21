using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeeknessAura : MonoBehaviour
{
    public Material glowFire;
    public Material glowIce;
    public Material glowDirt;

    SpriteRenderer spriteRenderer;
    HpStats hpStats;

    void Start(){
        hpStats = GetComponent<HpStats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnEnable();
        checkElement();
    }

    void OnEnable(){
        if(hpStats)hpStats.elementChanged += checkElement;
    }

    void OnDisable(){
        if(hpStats)hpStats.elementChanged -= checkElement;
    }

    void checkElement(){
        switch(hpStats.elementWeakness){
            case Element.fire:
                spriteRenderer.material = glowFire;
            break;

            case Element.ice:
                spriteRenderer.material = glowIce;
            break;

            case Element.earth:
                spriteRenderer.material = glowDirt;
            break;

        }
    }
}
