using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrafing : EnemyAction
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
        player = GameObject.Find("Player").transform;
    }

    public override void execute()
    {
        base.execute();
        Vector2 direction = (player.position - enemy.transform.position).normalized;
        float distance = Random.Range(avgDistance - distanceDiv, avgDistance + distanceDiv + 1);

        Vector2 multiplier;
        multiplier.x = Random.Range(-1f,1f);
        multiplier.y = Random.Range(-1f,1f);

        Vector2 strafeDirection = new Vector2(direction.y * multiplier.y, direction.x * multiplier.x).normalized;

        enemyMovement.setTarget((Vector2)enemy.transform.position + strafeDirection * distance);
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
