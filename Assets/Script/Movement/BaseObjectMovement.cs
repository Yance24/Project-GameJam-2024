using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectMovement : MonoBehaviour
{
    protected Rigidbody2D rigidbody2d;

    private const string isMoveParameterName = "";

    public bool isMoving = false;

    void Start(){
        // init animation controller;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    protected virtual void executeMovement(){
        isMoving = true;
        //set animation parameter;
    }

    protected virtual void stopMovement(){
        isMoving = false;
        //set animation parameter;
    }
}