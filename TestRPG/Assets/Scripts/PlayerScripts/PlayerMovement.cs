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

    private Dictionary<string, bool> position;
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
    private movementState state = movementState.stay;

    void Start()
    {
        body = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();

        StartPosition = "IsDown";
        SwitchToStay();

        up_left = new Vector2(-1, 1);
        up_right = new Vector2(1, 1);
        down_left = new Vector2(-1, -1);
        down_right = new Vector2(1, -1);
        empty_vector = new Vector2(0, 0);

        lastPos = new KeyValuePair<string, bool>(StartPosition, true);
        position = new Dictionary<string, bool>()
        {
            { "IsUp", false},
            { "IsDown", false},
            { "IsRight", false},
            { "IsLeft", false},
            { "IsUpLeft", false},
            { "IsUpRight", false},
            { "IsDownLeft", false},
            { "IsDownRight", false}
        };
        position[StartPosition] = true;
    }

    public void MovementSetter(Vector2 movement)
    {
        this.movement = movement;
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
        movement_sign = new Vector2(Math.Sign(movement.x), Math.Sign(movement.y));
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude * (currentSpeed / 5));

        if (movement_sign.Equals(empty_vector))
        {
            return;
        }

        position[lastPos.Key] = !lastPos.Value;

        switch (movement_sign)
        {
            case Vector2 v when v.Equals(up_left):
                position["IsUpLeft"] = true;
                lastPos = new KeyValuePair<string, bool>("IsUpLeft", true);
                break;
            case Vector2 v when v.Equals(up_right):
                position["IsUpRight"] = true;
                lastPos = new KeyValuePair<string, bool>("IsUpRight", true);
                break;
            case Vector2 v when v.Equals(down_left):
                position["IsDownLeft"] = true;
                lastPos = new KeyValuePair<string, bool>("IsDownLeft", true);
                break;
            case Vector2 v when v.Equals(down_right):
                position["IsDownRight"] = true;
                lastPos = new KeyValuePair<string, bool>("IsDownRight", true);
                break;

            case Vector2 v when v.Equals(Vector2.up):
                position["IsUp"] = true;
                lastPos = new KeyValuePair<string, bool>("IsUp", true);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                position["IsDown"] = true;
                lastPos = new KeyValuePair<string, bool>("IsDown", true);
                break;
            case Vector2 v when v.Equals(Vector2.right):
                position["IsRight"] = true;
                lastPos = new KeyValuePair<string, bool>("IsRight", true);
                break;
            case Vector2 v when v.Equals(Vector2.left):
                position["IsLeft"] = true;
                lastPos = new KeyValuePair<string, bool>("IsLeft", true);
                break;
        }

        LightController.LightTransform(lastPos.Key);

        foreach (var pos in position)
        {
            animator.SetBool(pos.Key, pos.Value);
        }
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + currentSpeed * Time.fixedDeltaTime * movement);
    }
}
