using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public HpStats targetHp;
    public RectTransform bar;

    float originalSize;

    void Start(){
        originalSize = bar.sizeDelta.x;
    }

    public void setTargetHp(HpStats target){
        targetHp = target;
        OnEnable();
        UpdateHpBar();
    }

    void OnEnable(){

        if(targetHp) targetHp.hpChanged += UpdateHpBar;
    }

    void OnDisable(){
        if(targetHp) targetHp.hpChanged -= UpdateHpBar;
    }

    void UpdateHpBar(){
        float hpPercentage = targetHp.CurrentHp / targetHp.maxHp;
        bar.sizeDelta = new Vector2(Mathf.Lerp(0,originalSize,hpPercentage),bar.sizeDelta.y);
    }
}
