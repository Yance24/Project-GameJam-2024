using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        Vector2 mousePosition = MouseUtil.mousePositionToWorld();
        if(mousePosition.x > transform.position.x)
            spriteRenderer.flipX = false;

        if(mousePosition.x < transform.position.x)
            spriteRenderer.flipX = true;
        
    }
}
