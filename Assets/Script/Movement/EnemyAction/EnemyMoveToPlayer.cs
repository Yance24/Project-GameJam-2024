using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveToPlayer : EnemyAction
{
    public float avgDistance;
    public float distanceDiv;
    EnemyMovement enemyMovement;
    Transform player;

    Coroutine coroutine;

    public override void setup(EnemyAI enemy)
    {
        base.setup(enemy);
        enemyMovement = enemy.GetComponent<EnemyMovement>();
        player = GameObject.FindWithTag("Player").transform;
    }

    public override void execute()
    {
        base.execute();
        // Debug.Log("Player: "+player.position);
        // Debug.Log("Enemy: "+enemy.transform.position);
        Vector2 direction = (player.position - enemy.transform.position).normalized;
        float distance = Random.Range(avgDistance - distanceDiv, avgDistance + distanceDiv + 1);
        // Debug.Log("Target: "+direction * distance);
        enemyMovement.setTarget((Vector2)enemy.transform.position + direction * distance);
        if(hasToFinish) {
            coroutine = StartCoroutine(checkFinish());
            Invoke("terminite",limitTimeSpan);
        }
        
    }

    void terminite(){
        StopCoroutine(coroutine);
        finish();
    }

    public override void finish()
    {
        base.finish();
        CancelInvoke("terminite");
    }

    IEnumerator checkFinish(){
        while(enemyMovement.isMoving){
            yield return new WaitForFixedUpdate();
        }
        finish();
    }

    
}