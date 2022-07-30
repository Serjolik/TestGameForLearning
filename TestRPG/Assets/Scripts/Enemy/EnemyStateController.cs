using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    private Vector2 movementVector;
    private enum State
    {
        search,
        hunt,
        attack
    }
    private State state = State.search;

    public void LostTarget()
    {
        state = State.search;
    }
    public void Find()
    {
        state = State.hunt;
    }
    public void InRange()
    {
        state = State.attack;
    }

    public Vector2 EnemyMovement(Vector2 ourPosition, Vector2 targetPosition, Vector2 pointPosition)
    {
        switch (state)
        {
            case State.search:
                Search(ourPosition, pointPosition);
                break;
            case State.hunt:
                Hunt(ourPosition, targetPosition);
                break;
            case State.attack:
                ToAttack(ourPosition);
                break;
            default:
                Debug.Log("Unknown enemy state");
                break;
        }
        return movementVector;
    }

    public bool Reached(Vector2 ourPosition, Vector2 targetPosition)
    {
        if (MovingToPoint.Instance.ReachedThePoint(ourPosition, targetPosition))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Search(Vector2 ourPosition, Vector2 pointPosition)
    {
        movementVector = MovingToPoint.Instance.Movement(ourPosition, pointPosition);
    }
    private void Hunt(Vector2 ourPosition, Vector2 targetPosition)
    {
        movementVector = MovingToPoint.Instance.Movement(ourPosition, targetPosition);
    }
    private void ToAttack(Vector2 ourPosition)
    {
        movementVector = ourPosition;
    }

}
