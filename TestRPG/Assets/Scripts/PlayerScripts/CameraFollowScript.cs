//This File is required for tests, but not for the game to work.
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform followTransform;

    void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
