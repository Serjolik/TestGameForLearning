using System.Collections.Generic;
using UnityEngine;

public class GhostLogic : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private MovingToPoint movingToPoint;
    [SerializeField] private EnemyStateController enemyStateController;
    [Header("Variables")]
    [SerializeField] private float distanceToAttack = 1f;
    [SerializeField] private float visionDistance = 10f;
    [Header("ObjectsTransform")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform ghostTransform;
    [Header("MovementPathTransforms")]
    [SerializeField] private Transform[] MovementPaths;

    private List<Transform> Paths = new List<Transform>();
    private int numberOfPaths = 0;
    private int currentPath = 0;
    private bool haunted = false;

    private float distanceToPlayer;
    private bool inAttackRange => distanceToPlayer <= distanceToAttack;
    private bool inVisionRange => distanceToPlayer <= visionDistance;

    private void Awake()
    {
        foreach (Transform transforms in MovementPaths)
        {
            numberOfPaths++;
            Paths.Add(transforms);
        }

        if (numberOfPaths <= 0)
        {
            Debug.Log("No paths, object deactivated");
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        Vector2 ourPositionEdited = new Vector2(ghostTransform.position.x, ghostTransform.position.y);
        Vector2 playerPositionEdited = new Vector2(playerTransform.position.x, playerTransform.position.y);
        Vector2 pointPositionEdited = new Vector2(Paths[currentPath].position.x, Paths[currentPath].position.y);
        distanceToPlayer = Vector2.Distance(ourPositionEdited, playerPositionEdited);

        if (!inVisionRange)
        {
            enemyStateController.LostTarget();
            if (haunted)
            {
                haunted = false;
                FindPath(ourPositionEdited, Vector2.Distance(ourPositionEdited, pointPositionEdited));
                pointPositionEdited = new Vector2(Paths[currentPath].position.x, Paths[currentPath].position.y);
            }
            if (movingToPoint.ReachedThePoint(ourPositionEdited, pointPositionEdited))
            {
                PathChange();
            }
        }
        else // if player in vision range
        {
            haunted = true;
            if (!inAttackRange)
            {
                enemyStateController.Find();
            }
            else
            {
                enemyStateController.InRange();
            }
        }
        ghostTransform.position = enemyStateController.EnemyMovement(ourPositionEdited, playerPositionEdited, pointPositionEdited);
    }

    private void PathChange()
    {
        currentPath++;
        currentPath %= numberOfPaths;
    }

    

    private void FindPath(Vector2 ourPosition, float distanceToLastPoint)
    {
        int index = 0;
        int minDistanceIndex = 0;
        float minDistance = distanceToLastPoint;

        foreach (Transform transforms in MovementPaths)
        {
            Vector2 pathPosition = new Vector2(transforms.position.x, transforms.position.y);
            float currentDistance = Vector2.Distance(ourPosition, pathPosition);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                minDistanceIndex = index;
            }
            index++;
        }
        currentPath = minDistanceIndex;

    }

}
