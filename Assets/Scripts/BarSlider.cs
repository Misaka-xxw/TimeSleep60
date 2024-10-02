using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarSlider : MonoBehaviour
{
    public Slider slider;

    protected void Start()
    {
        slider.interactable = false;
    }
    public void UpdateSlider(float cur, float max)
    {
        cur = cur > 0 ? cur : 0;
        slider.value = cur / max;
    }
}