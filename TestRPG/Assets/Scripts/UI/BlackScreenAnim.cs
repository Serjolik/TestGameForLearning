using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BlackScreenAnim : MonoBehaviour
{
    [SerializeField] private float animationTime = 2f;
    private Image ObjectImage;
    private Color fullColor;
    private Color transparentColor;

    private void Awake()
    {
        ObjectImage = GetComponent<Image>();
        fullColor = ObjectImage.color;
        fullColor.a = 1f;
        transparentColor = ObjectImage.color;
        transparentColor.a = 0f;
    }

    private void Update()
    {
        Test();
    }

    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(anim());
        }
    }

    private IEnumerator anim()
    {
        float time = 0;
        float step = 1f / animationTime;

        while (time < animationTime)
        {
            time += Time.deltaTime;
            ObjectImage.color = Color.Lerp(transparentColor, fullColor, step * time);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        time = 0;
        while (time < animationTime)
        {
            time += Time.deltaTime;
            ObjectImage.color = Color.Lerp(fullColor, transparentColor, step * time);
            yield return null;
        }
    }
}
