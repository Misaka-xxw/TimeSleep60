using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 表情
public class Expression : MonoBehaviour
{
    public List<GameObject> expressions;
    private int _visibleIdx=0,_lastIdx=0;
    public void SetExpression(int n)
    {
        expressions[n].SetActive(true);
        if(n==0)
            expressions[1].SetActive(true);
        if (_visibleIdx == n)
            return;
        expressions[_visibleIdx].SetActive(false);
        if(_visibleIdx==0)
            expressions[1].SetActive(false);
        _visibleIdx = n;
    }

    public void Set1Second(int n)
    {
        StartCoroutine(Set1SecondIE(n));
    }
    public IEnumerator Set1SecondIE(int n)
    {
        SetExpression(n);
        yield return new WaitForSeconds(1);
        if(_visibleIdx==n)
            SetExpression(0);
    }
}
