using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : BaseObjectMovement
{
    public float speed;
    protected Vector2 targetPosition;

    bool isReached = true;

    public void setTarget(Vector2 target){
        this.targetPosition = target;
        executeMovement();
        isReached = false;
        
    }

    void Update(){
        if(!isReached){
            Vector2 direction = (targetPosition - rigidbody2d.position).normalized;
            Vector2 newPosition = rigidbody2d.position + direction * speed;        
            rigidbody2d.MovePosition(newPosition);
            if(Vector2.Distance(rigidbody2d.position, targetPosition) <= 0.1){
                isReached = true;
                stopMovement();
            }

        }
    }
}
