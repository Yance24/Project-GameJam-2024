using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float aggroDistance;
    public float loseAggroDistance;
    public List<EnemyAction> actionNonAggro;
    public List<EnemyAction> actionAggro;
    public float avgActionSpeed;
    public float actionDev;
    public float speedAggroMultiplier;
    public float speedNoAggroMultiplier;

    public static Action totalEnemyAggroOnChange;
    private static int totalEnemyAggro;
    public static int TotalEnemyAggro{
        set{
            totalEnemyAggro = value;
            totalEnemyAggroOnChange?.Invoke();
        }
        get{return totalEnemyAggro;}
    }

    public Transform player;

    private Coroutine currentAction;

    bool isAggro = false;

    void Start(){
        player = GameObject.FindWithTag("Player").transform;
        currentAction = StartCoroutine(nonAggroedAction());
    }

    void checkDistance(){
        if(!isAggro && Vector2.Distance(transform.position,player.position) <= aggroDistance){
            if(currentAction != null) StopCoroutine(currentAction);
            isAggro = true;
            currentAction = StartCoroutine(aggroedAction());
            TotalEnemyAggro++;
            if(gameObject.CompareTag("Boss")){
                GameObject bossHpUi = GameObjectUtils.FindInactiveObjectByName("Boss Hp Bar");
                bossHpUi.SetActive(true);
                bossHpUi.GetComponent<HpBar>().setTargetHp(GetComponent<HpStats>());
            }
            // Debug.Log("Aggro!!");
        }else if(isAggro && Vector2.Distance(transform.position,player.position) >= loseAggroDistance){
            if(currentAction != null) StopCoroutine(currentAction);
            isAggro = false;
            currentAction = StartCoroutine(nonAggroedAction());
            // TotalEnemyAggro--;
            // Debug.Log("Lose Aggro!!");
        }

    }

    float countActionSpeed(float multiplier){
        return UnityEngine.Random.Range(avgActionSpeed - actionDev, avgActionSpeed + actionDev + 1) / multiplier;
    }

    void FixedUpdate(){
        checkDistance();
    }

    IEnumerator aggroedAction(){
        if(actionAggro.Count <= 0) yield break;
        yield return null;
        int index = 0;
        EnemyAction enemyAction;
        while(true){
            enemyAction = actionAggro[index];
            enemyAction.setup(this);
            enemyAction.execute();

            while(!enemyAction.isFinished && enemyAction.hasToFinish){
                yield return new WaitForSeconds(0.1f);
            }


            if(++index >= actionAggro.Count) index = 0;
            yield return new WaitForSeconds(countActionSpeed(speedAggroMultiplier));
        }
    }

    IEnumerator nonAggroedAction(){
        if(actionNonAggro.Count <= 0) yield break;
        yield return null;
        int index = 0;
        EnemyAction enemyAction;
        while(true){
            enemyAction = actionNonAggro[index];
            enemyAction.setup(this);
            enemyAction.execute();

            while(!enemyAction.isFinished && enemyAction.hasToFinish){
                yield return new WaitForSeconds(0.1f);
            }

            if(++index >= actionNonAggro.Count) index = 0;
            yield return new WaitForSeconds(countActionSpeed(speedNoAggroMultiplier));
        }
    }
}
