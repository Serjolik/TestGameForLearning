using UnityEngine;

public class MoonScript : MonoBehaviour
{
    [SerializeField] private GameObject Moon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Moon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Moon.SetActive(false);
    }

}
