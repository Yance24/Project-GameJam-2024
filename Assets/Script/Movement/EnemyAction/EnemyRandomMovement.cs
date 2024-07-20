using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : EnemyAction
{
    public float avgDistance;
    public float distanceDiv;
    EnemyMovement enemyMovement;
    Coroutine coroutine;

    public override void setup(EnemyAI enemy)
    {
        base.setup(enemy);
        enemyMovement = enemy.GetComponent<EnemyMovement>();
    }
    public override void execute()
    {
        base.execute();
        Vector2 direction = Random.insideUnitCircle.normalized;
        float distance =  Random.Range(avgDistance - distanceDiv, avgDistance + distanceDiv + 1);
        // Debug.Log(direction * distance);
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
