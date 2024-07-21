using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWait : EnemyAction
{
    public float avgWaitTime;
    public float waitTimeDiv;

    public override void execute()
    {
        base.execute();
        Invoke("finish",Random.Range(avgWaitTime - waitTimeDiv, avgWaitTime + waitTimeDiv + 1));
    }

}
