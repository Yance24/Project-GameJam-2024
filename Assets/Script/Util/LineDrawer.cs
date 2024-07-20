using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    public static void drawUiLine(Vector2 pointA, Vector2 pointB, Image lineImage){
        // Calculate the distance between the points
        float distance = Vector3.Distance(pointA, pointB);

        // Set the size of the line
        lineImage.rectTransform.sizeDelta = new Vector2(distance, lineImage.rectTransform.sizeDelta.y);

        // Set the position of the line (midpoint between the points)
        lineImage.rectTransform.localPosition = (pointA + pointB) / 2;

        // Calculate the angle between the points
        Vector3 direction = pointB - pointA;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the line
        lineImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
