using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollows : MonoBehaviour
{
    public Transform objects;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objects.position.x,objects.position.y,-10);
    }
}
