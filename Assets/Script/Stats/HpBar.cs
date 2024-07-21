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

    void Awake(){
        originalSize = bar.sizeDelta.x;
    }

    public void setTargetHp(HpStats target){
        targetHp = target;
        
        OnEnable();
        UpdateHpBar();
    }

    void OnEnable(){
        if(targetHp) targetHp.hpChanged += UpdateHpBar;
        // Debug.Log(targetHp);
    }

    void OnDisable(){
        if(targetHp) targetHp.hpChanged -= UpdateHpBar;
    }

    void UpdateHpBar(){
        // Debug.Log("Target HP "+ targetHp.CurrentHp + " / "+targetHp.maxHp);
        // Debug.Log("size: "+originalSize);
        float hpPercentage = targetHp.CurrentHp / targetHp.maxHp;
        bar.sizeDelta = new Vector2(Mathf.Lerp(0,originalSize,hpPercentage),bar.sizeDelta.y);
    }
}
