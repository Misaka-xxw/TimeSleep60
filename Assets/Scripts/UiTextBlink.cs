using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiTextBlink : MonoBehaviour
{
    public Text text;
    public float blinkSpeed = 0.5f;
    public float maxAlpha = 100f;
    public float blinkTime = 0.4f;

    public IEnumerator IncreaseAlpha()
    {
        while (true)
        {
            Color newColor = text.color;
            var a = newColor.a;
            Debug.Log(a);
            a += Time.deltaTime * blinkSpeed;
            if (a >= 100f)
            {
                newColor.a = 100f;
                text.color = newColor;
                yield break;
            }
            newColor.a = a;
            text.color = newColor;
            yield return null;
        }
    }
    public IEnumerator Blink()
    {
        Color newColor = text.color;
        newColor.a = 0f;
        text.color = newColor;
        yield return new WaitForSeconds(blinkTime);
        newColor.a = 100f;
        text.color = newColor;
        yield return new WaitForSeconds(blinkTime);
        newColor.a = 0f;
        text.color = newColor;
    }
}