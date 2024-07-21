using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[SerializeField]
public enum Element{
    fire, ice, wind, dark
}

public class HpStats : MonoBehaviour
{
    public float maxHp;
    public GameEvent deadEvent;
    public bool removeOnDead;

    private float currentHp;

    public Element elementWeakness;

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
            if(Mathf.Floor(currentHp) <= 0){
                // Debug.Log("dead");
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
