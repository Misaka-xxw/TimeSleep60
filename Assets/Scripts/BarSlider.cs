using UnityEngine;
using UnityEngine.UI;

// 血条，或者时间条的基类
public class BarSlider : MonoBehaviour
{
    public Slider slider;

    protected void Start()
    {
        if(slider!=null)
            slider.interactable = false;
    }
    public void UpdateSlider(float cur, float max)
    {
        cur = cur > 0f ? cur : 0f;
        slider.value = cur / max;
    }

    public void UpdateSlider(float cur)
    {
        cur = cur > 0f ? cur : 0f;
        slider.value = cur;
    }
    public void UpdateSlider(int cur)
    {
        cur = cur > 0 ? cur : 0;
        slider.value = cur;
    }
}