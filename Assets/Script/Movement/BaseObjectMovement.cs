using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;
    protected Animator animator;

    private const string isMoveParameterName = "isMoving";

    public bool isMoving = false;

    void Start(){
        // init animation controller;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    protected virtual void executeMovement(){
        isMoving = true;
        if(animator) animator.SetBool(isMoveParameterName,true);
        
    }

    protected virtual void stopMovement(){
        isMoving = false;
        if(animator) animator.SetBool(isMoveParameterName,false);
    }
}