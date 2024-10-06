using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;

public class SpeedButton : MonoBehaviour
{
    public Text text;
    private int _idx = 2;
    [ReadOnly]
    private float[] _speed = { 0.5f, 0.75f, 1f, 1.25f, 1.5f, 2f, 3f };
    [ReadOnly]
    private string[] _speedText = { "x0.5", "x0.75", "x1.0", "x1.25", "x1.5", "x2.0", "x3.0" };

    private bool _isPause;
    
    public void OnButtonClick()
    {
        _idx=(_idx+1)%7;
        Time.timeScale = _speed[_idx];
        text.text = _speedText[_idx];
    }

    public void OnPause()
    {
        if (_isPause)
        {
            Time.timeScale = _speed[_idx];
            _isPause = false;
        }
        else
        {
            Time.timeScale = 0f;
            _isPause = true;
        }
    }
}
