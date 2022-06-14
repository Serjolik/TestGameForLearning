using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public Animator animator;

    public float runSpeed = 5.0f;

    private Dictionary<string, bool> position;

    public KeyValuePair<string, bool> lastPos { get; private set; }

    private static string StartPosition = "IsDown";

    public LightController LightController;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
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
        if (DialogeManager.GetInstance().dialogeIsPlaying)
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
                LightController.LightTransform(lastPos.Key);
                break;
            case Vector2 v when v.Equals(Vector2.down):
                position[lastPos.Key] = !lastPos.Value;
                position["IsDown"] = true;
                lastPos = new KeyValuePair<string, bool>("IsDown", true);
                LightController.LightTransform(lastPos.Key);
                break;
            case Vector2 v when v.Equals(Vector2.right):
                position[lastPos.Key] = !lastPos.Value;
                position["IsRight"] = true;
                lastPos = new KeyValuePair<string, bool>("IsRight", true);
                LightController.LightTransform(lastPos.Key);
                break;
            case Vector2 v when v.Equals(Vector2.left):
                position[lastPos.Key] = !lastPos.Value;
                position["IsLeft"] = true;
                lastPos = new KeyValuePair<string, bool>("IsLeft", true);
                LightController.LightTransform(lastPos.Key);
                break;
        }
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
