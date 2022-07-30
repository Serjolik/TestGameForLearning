using UnityEngine;

public class DrawingTrigger : MonoBehaviour
{
    private Vector3 objectPosition;
    void Awake()
    {
        objectPosition = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objectPosition.z -= 2;
            positionTransform();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objectPosition.z += 2;
            positionTransform();
        }
    }

    private void positionTransform()
    {
        this.transform.position = objectPosition;
    }
}
