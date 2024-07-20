using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUtil : MonoBehaviour
{
    public static Vector2 mousePositionToRect(RectTransform localRect){
        Vector2 localPoint;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(localRect,Input.mousePosition,Camera.main, out localPoint)){
            // Debug.Log("Local Point : "+localPoint);
            return localPoint;
        }
        else return new Vector2();
    }
}
