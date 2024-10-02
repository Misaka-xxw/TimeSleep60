using UnityEngine;
using UnityEngine.UI;

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