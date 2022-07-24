using UnityEngine;

public class MovingToPoint
{
    [SerializeField] private float speed = 100f;
    public Vector2 Movement(Vector2 ourPosition, Vector2 targetPosition)
    {
        return Vector2.MoveTowards(ourPosition, targetPosition, speed * Time.deltaTime);
    }

    public bool ReachedThePoint(Vector2 ourPosition, Vector2 targetPosition)
    {
        if (Vector2.Distance(ourPosition, targetPosition) <= 0.01f)
            return true;
        else
            return false;
    }

    public bool ReachedTheAttack(Vector2 ourPosition, Vector2 targetPosition, float attackRange)
    {
        if (Vector2.Distance(ourPosition, targetPosition) <= attackRange)
            return true;
        else
            return false;
    }

}
