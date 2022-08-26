using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BlackScreenAnim : MonoBehaviour
{
    [SerializeField] private float animationTime = 2f;
    private bool inCutscene = false;
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

    public void PlayAnimation(float animationPauseTime)
    {
        StartCoroutine(anim(animationPauseTime));
        Debug.Log("Black screen");
    }

    public float giveAnimationTime()
    {
        return animationTime;
    }

    public bool giveInCutsceneState()
    {
        return inCutscene;
    }

    private IEnumerator anim(float animationPauseTime)
    {
        float time = 0;
        float step = 1f / animationTime;

        while (time < animationTime)
        {
            time += Time.deltaTime;
            ObjectImage.color = Color.Lerp(transparentColor, fullColor, step * time);
            yield return null;
        }
        inCutscene = true;
        yield return new WaitForSeconds(animationPauseTime);
        inCutscene = false;
        time = 0;
        while (time < animationTime)
        {
            time += Time.deltaTime;
            ObjectImage.color = Color.Lerp(fullColor, transparentColor, step * time);
            yield return null;
        }
    }
}
