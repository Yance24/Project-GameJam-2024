using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Rendering;

[SerializeField]
public enum Element{
    fire, ice, earth, dark
}

public class HpStats : MonoBehaviour
{
    public float maxHp;
    public GameEvent deadEvent;
    public bool removeOnDead;

    public Action hpChanged;

    private float currentHp;

    public Element elementWeakness;

    public Action elementChanged;

    public void changeElement(Element element){
        elementWeakness = element;
        elementChanged?.Invoke();
    }

    void Start(){
        currentHp = maxHp;
    }

    public string HpString{
        get{return ""+Mathf.Floor(currentHp)+" / "+maxHp;}
    }

    public float CurrentHp{
        get{return currentHp;}
        set{
            currentHp = value;
            // Debug.Log(value);
            hpChanged?.Invoke();
            if(Mathf.Floor(currentHp) <= 0){
                // Debug.Log("dead");
                if(gameObject.tag == "Enemy" || gameObject.tag == "Boss"){
                    EnemyAI enemyAI = GetComponent<EnemyAI>();
                    if(enemyAI && enemyAI.isAggro){
                        EnemyAI.TotalEnemyAggro--;
                    }
                }
                
                
                if(deadEvent) {
                    deadEvent.execute();
                    StartCoroutine(checkDeadEvent());
                }else if(removeOnDead) Destroy(gameObject);
            }
        }
    }

    IEnumerator checkDeadEvent(){
        while(!deadEvent.isFinished){
            yield return new WaitForSeconds(1);
        }
        if(removeOnDead){
            Destroy(gameObject);
        }
        yield break;
    }
}