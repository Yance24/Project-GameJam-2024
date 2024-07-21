using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMousePosition : MonoBehaviour
{
    EnemyMovement enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)){
            enemyMovement.setTarget(MouseUtil.mousePositionToWorld());
        }
    }
}
