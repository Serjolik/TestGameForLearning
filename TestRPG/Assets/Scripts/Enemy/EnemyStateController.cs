using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    [SerializeField] private MovingToPoint movingToPoint;
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
                ToAttack();
                break;
            default:
                Debug.Log("Unknown enemy state");
                break;
        }
        return movementVector;
    }

    private void Search(Vector2 ourPosition, Vector2 pointPosition)
    {
        movementVector = movingToPoint.Movement(ourPosition, pointPosition);
    }
    private void Hunt(Vector2 ourPosition, Vector2 targetPosition)
    {
        movementVector = movingToPoint.Movement(ourPosition, targetPosition);
    }
    private void ToAttack()
    {
        movementVector = new Vector2(0, 0);
    }

}
