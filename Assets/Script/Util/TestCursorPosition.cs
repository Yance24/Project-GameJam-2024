using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCursorPosition : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
