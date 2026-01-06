using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public float speed = 100f; // Movement speed in pixels/second
    public Vector2 pointA = new Vector2(400, 400); // Northeast corner
    public Vector2 pointB = new Vector2(-400, -400); // Southwest corner

    private RectTransform rectTransform;
    private Vector2 target;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = pointA; // Start at northeast
        target = pointB;
    }

    void Update()
    {
        rectTransform.anchoredPosition = Vector2.MoveTowards(
            rectTransform.anchoredPosition,
            target,
            speed * Time.deltaTime
        );

        // If reached the target, reverse direction
        if (Vector2.Distance(rectTransform.anchoredPosition, target) < 1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
