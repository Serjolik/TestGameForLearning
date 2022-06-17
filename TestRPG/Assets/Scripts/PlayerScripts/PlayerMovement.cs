using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats player;

    [Header("PlayerObjects")]
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator animator;
    [SerializeField] private LightController LightController;


    private float runSpeed;

    private Dictionary<string, bool> position;
    public KeyValuePair<string, bool> lastPos { get; private set; }
    private static string StartPosition = "IsDown";
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        runSpeed = player.PlayerSpeed();
        body = GetComponent<Rigidbody2D>();
        lastPos = new KeyValuePair<string, bool>(StartPosition, true);
        position = new Dictionary<string, bool>()
        {
            { "IsUp", false},
            { "IsDown", false},
            { "IsRight", false},
            { "IsLeft", false}
        };
    }

    private void Update()
    {
        if (DialogeManager.GetInstance().dialogeIsPlaying || !player.PlayerIsAlive())
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        switch (movement)
        {
            case Vector2 v when v.Equals(Vector2.up):
                position[lastPos.Key] = !lastPos.Value;
                position["IsUp"] = true;
                lastPos = new KeyValuePair<string, bool>("IsUp", true);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                position[lastPos.Key] = !lastPos.Value;
                position["IsDown"] = true;
                lastPos = new KeyValuePair<string, bool>("IsDown", true);
                break;
            case Vector2 v when v.Equals(Vector2.right):
                position[lastPos.Key] = !lastPos.Value;
                position["IsRight"] = true;
                lastPos = new KeyValuePair<string, bool>("IsRight", true);
                break;
            case Vector2 v when v.Equals(Vector2.left):
                position[lastPos.Key] = !lastPos.Value;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(body.position + runSpeed * Time.fixedDeltaTime * movement);
    }
}
