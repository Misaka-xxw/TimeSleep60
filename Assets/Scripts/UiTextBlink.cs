using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiTextBlink : MonoBehaviour
{
    public Text text;
    public float blinkSpeed = 0.5f;

    public void changeText(string s)
    {
        text.text = s;
    }
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
    public IEnumerator Blink(float blinkTime,bool bright=true)
    {
        Color newColor = text.color;
        newColor.a = bright?100f:0f;
        text.color = newColor;
        yield return new WaitForSeconds(blinkTime);
    }
}