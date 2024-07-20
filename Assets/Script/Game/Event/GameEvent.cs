using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public bool isRunning = false;
    public bool isFinished = true;
    public virtual void execute(){
        isRunning = true;
        isFinished = false;
    }

    public virtual void finish(){
        isRunning = false;
        isFinished = true;
    }
}
