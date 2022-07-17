using UnityEngine;
using System.Collections.Generic;
using System;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerScripts")]
    [SerializeField] private LightController LightController;
    [Header("Variables")]
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float walkSpeed = 3f;
    private float staySpeed = 0f;
    private float currentSpeed;

    private Rigidbody2D body;
    private Animator animator;
    public KeyValuePair<string, bool> lastPos { get; private set; }
    private static string StartPosition;

    private Vector2 movement;
    private Vector2 movement_sign;
    private Vector2 up_left;
    private Vector2 up_right;
    private Vector2 down_left;
    private Vector2 down_right;
    private Vector2 empty_vector;

    private enum movementState
    {
        walk,
        run,
        stay
    }

    private enum position
    {
        IsUp,
        IsDown,
        IsRight,
        IsLeft,
        IsUpLeft,
        IsUpRight,
        IsDownLeft,
        IsDownRight
    }
    private position currentPosition;
    private position lastPosition;

    void Start()
    {
        body = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        SwitchToStay();

        up_left = new Vector2(-1, 1);
        up_right = new Vector2(1, 1);
        down_left = new Vector2(-1, -1);
        down_right = new Vector2(1, -1);

        lastPos = new KeyValuePair<string, bool>(StartPosition, true);

        currentPosition = position.IsDown;
        lastPosition = position.IsDown;
    }

    public void MovementSetter(Vector2 movement)
    {
        this.movement = movement;
        movement_sign = new Vector2(Math.Sign(movement.x), Math.Sign(movement.y));
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }

    public void SwitchToRun()
    {
        currentSpeed = StateHandler(movementState.run);
    }
    public void SwitchToWalk()
    {
        currentSpeed = StateHandler(movementState.walk);
    }
    public void SwitchToStay()
    {
        currentSpeed = StateHandler(movementState.stay);
    }

    private float StateHandler(movementState state)
    {
        switch (state)
        {
            case movementState.run:
                return runSpeed;
            case movementState.walk:
                return walkSpeed;
            case movementState.stay:
                return staySpeed;
            default:
                Debug.Log("movement state is not defined");
                return staySpeed;
        }
    }

    private void Update()
    {
        animator.SetFloat("Speed", movement.sqrMagnitude * (currentSpeed / 5));

        if (movement_sign.Equals(empty_vector))
        {
            return;
        }

        lastPosition = currentPosition;

        switch (movement_sign)
        {
            case Vector2 v when v.Equals(up_left):
                currentPosition = position.IsUpLeft;
                break;
            case Vector2 v when v.Equals(up_right):
                currentPosition = position.IsUpRight;
                break;
            case Vector2 v when v.Equals(down_left):
                currentPosition = position.IsDownLeft;
                break;
            case Vector2 v when v.Equals(down_right):
                currentPosition = position.IsDownRight;
                break;

            case Vector2 v when v.Equals(Vector2.up):
                currentPosition = position.IsUp;
                break;
            case Vector2 v when v.Equals(Vector2.down):
                currentPosition = position.IsDown;
                break;
            case Vector2 v when v.Equals(Vector2.right):
                currentPosition = position.IsRight;
                break;
            case Vector2 v when v.Equals(Vector2.left):
                currentPosition = position.IsLeft;
                break;
        }

        LightController.LightTransform(currentPosition.ToString());

        animator.SetBool(lastPosition.ToString(), false);
        animator.SetBool(currentPosition.ToString(), true);
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + currentSpeed * Time.fixedDeltaTime * movement);
    }
}
