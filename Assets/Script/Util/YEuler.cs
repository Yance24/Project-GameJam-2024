using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YEuler
{
    public static float countAngle(Vector3 source, Vector3 target){
        Vector3 direction = target - source;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}
