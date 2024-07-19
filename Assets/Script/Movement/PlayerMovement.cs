using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseObjectMovement
{
    public float speed;
    private Vector2 inputDirection;
    // Update is called once per frame
    void Update()
    {
        
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
        
        if(inputDirection.magnitude > 0) executeMovement();
        else stopMovement();

        rigidbody2d.velocity = inputDirection.normalized * speed;
    }
}
