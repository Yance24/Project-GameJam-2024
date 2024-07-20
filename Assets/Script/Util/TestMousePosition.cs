using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMousePosition : MonoBehaviour
{
    RectTransform rectTransform;
    public RectTransform referencePoint;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localPosition = MouseUtil.mousePositionToRect(referencePoint);
    }
}
