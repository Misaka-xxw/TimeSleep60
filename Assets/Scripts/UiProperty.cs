using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiProperty : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> model;//4个至少
    public GridLayout gridLayout;
    public List<string> propertyName;
    public List<Sprite> sprites;
    
    public void UpdateItem(int num)
    {
        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                var obj = Instantiate(model[j]);
                RectTransform rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.localScale = new Vector3(1f,1f);
                obj.transform.parent = this.gameObject.transform;
                if (j == 0&&sprites[i]!=null)
                {
                    Image image = obj.GetComponent<Image>();
                    image.sprite = sprites[i];
                }
                if (j == 1)
                {
                    Text text = obj.GetComponent<Text>();
                    text.text = propertyName[i];
                }
            }
        }
    }
}
