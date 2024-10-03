using UnityEngine;
using UnityEngine.UI;

// ui跟踪精灵，要调到世界模式
public class UITracker : MonoBehaviour
{
    public Transform spriteToTrack;
    public RectTransform uiElementToTrackWith;

    private void Update()
    {
        if (spriteToTrack!= null && uiElementToTrackWith!= null)
        {
            uiElementToTrackWith.position = spriteToTrack.position;
        }
    }
}