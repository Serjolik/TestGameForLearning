using UnityEngine;
public class Portal : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] private Transform PlayerPosition;
    [SerializeField] private Transform CameraPosition;

    [Header("Positions")]
    [SerializeField] private Vector3 newPlayerPosition;
    [SerializeField] private Vector3 newCameraPosition;

    /*
     * fixed positions on start scene
     * newPlayerPosition FR = new Vector3(0f, 9.5f, -1f); SR = (0f, 3f, -1f)
     * newCameraPosition FR = new Vector3(0f, 13f, -10f); SR = (0f, 0f, -10f)
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPosition.position = newPlayerPosition;
            CameraPosition.position = newCameraPosition;
        }
    }
}
