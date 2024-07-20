using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public float limitTimeSpan;
    public bool hasToFinish = true;
    public bool isRunning = false;
    public bool isFinished = true;

    protected EnemyAI enemy;

    public virtual void setup(EnemyAI enemy){
        this.enemy = enemy;
    }

    public virtual void execute(){
        isRunning = true;
        isFinished = false;
    }

    public virtual void finish(){
        isRunning = false;
        isFinished = true;
    }

}
