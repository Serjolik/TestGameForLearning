using UnityEngine;

public class MovingToPoint : ScriptableObject
{
    private static MovingToPoint instance;
    public static MovingToPoint Instance
    {
        get
        {
            if (instance == null)
            {
                instance = CreateInstance<MovingToPoint>();
            }
            return instance;
        }
    }
    private float speed = 1f;    

    private void Awake()
    {
        instance = this;
    }

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
