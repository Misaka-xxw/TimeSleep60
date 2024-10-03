using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiProperty : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> model; //4个至少
    public GridLayout gridLayout;
    public List<string> propertyName, dataStr;
    public List<Text> labels, datas;


    public void UpdateItem(int num)
    {
        for (int i = 0; i < num; i++)
        {
            labels[i].text = propertyName[i];
            datas[i].text = dataStr[i];
        }

        for (int i = num; i < propertyName.Count; i++)
        {
            labels[i].text = "";
            datas[i].text = "";
        }
    }
}