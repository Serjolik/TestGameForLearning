using UnityEngine;
public class Portal : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform CameraPosition;

    [Header("Positions")]
    [SerializeField] private Vector3 NewPlayerPosition;
    [SerializeField] private Vector3 NewCameraPosition;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPosition.position = NewPlayerPosition;
            CameraPosition.position = NewCameraPosition;
        }
    }
}
