using UnityEngine;

public class UiPropertyTest : MonoBehaviour
{
    private UiProperty uiProperty;
    public int testNum;

    void Start()
    {
        uiProperty = GetComponent<UiProperty>();
        uiProperty.UpdateItem(testNum);
    }
}