using UnityEngine;

public class MoveUIToTarget : BaseObjectMovement
{
    public float speed;
    private RectTransform sourceUI;
    private Vector2 targetPosition;

    bool isReached = true;

    public void setTarget(Vector2 target){
        this.targetPosition = target;
        isReached = false;
    }

    void Start(){
        sourceUI = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (sourceUI != null && !isReached) 
        {
            // Smoothly move the sourceUI towards the targetPosition
            sourceUI.anchoredPosition = Vector2.Lerp(sourceUI.anchoredPosition, targetPosition, speed * Time.deltaTime);
            
            // Optionally, you can stop the movement when it gets very close to the target position
            if (Vector2.Distance(sourceUI.anchoredPosition, targetPosition) < 0.1f)
            {
                sourceUI.anchoredPosition = targetPosition;
                isReached = true;
            }
        }
    }
}
