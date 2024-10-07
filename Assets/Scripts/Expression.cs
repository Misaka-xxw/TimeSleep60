using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 表情
public class Expression : MonoBehaviour
{
    public List<GameObject> expressions;
    private int _visibleIdx=0,_lastIdx=0;
    public void SetExpression(int n)
    {
        expressions[n].SetActive(true);
        expressions[_visibleIdx].SetActive(false);
        _visibleIdx = n;
    }
}
