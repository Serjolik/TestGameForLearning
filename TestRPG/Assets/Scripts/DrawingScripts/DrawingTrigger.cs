using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingTrigger : MonoBehaviour
{
    private Vector3 objectPosition;
    // Start is called before the first frame update
    void Start()
    {
        objectPosition = this.transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objectPosition.z--;
            positionTransform();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objectPosition.z++;
            positionTransform();
        }
    }

    private void positionTransform()
    {
        this.transform.position = objectPosition;
    }
}
