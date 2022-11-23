using UnityEngine;
using UnityEngine.UIElements;

public class DrawingTrigger : ObjectController
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            position.z -= 2;
            positionTransform();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            position.z += 2;
            positionTransform();
        }
    }

    private void positionTransform()
    {
        this.transform.position = position;
    }
}
