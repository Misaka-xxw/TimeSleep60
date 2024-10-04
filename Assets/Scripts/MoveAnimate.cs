using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum  Condition
{
    LeftMove,RightMove,Stop
}

// 移动是否水平翻转
public class MoveAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform girlTransform;
    public LifeThing lifeThing;
    public float downV, upV;
    private bool _haveLifeThing;
    private Condition _condition=Condition.LeftMove;
    public Animator animator;
    void Start()
    {
        girlTransform = GetComponent<Transform>();
        lifeThing = GetComponent<LifeThing>();
        animator = GetComponent<Animator>();
        _haveLifeThing = (lifeThing != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (_haveLifeThing && !lifeThing.isAlive )
        {
            Destroy(this);//去掉这个组件
        }
        var x = Input.GetAxis("Horizontal");
        if (x < downV)
        {
            if (_condition != Condition.LeftMove)
            {
                _condition = Condition.LeftMove;
                girlTransform.localScale=new Vector3(Math.Abs(girlTransform.localScale.x),girlTransform.localScale.y);
            }
        }
        
        else if (x>upV)
        {
            if (_condition != Condition.RightMove)
            {
                _condition = Condition.RightMove;
                girlTransform.localScale=new Vector3(-Math.Abs(girlTransform.localScale.x),girlTransform.localScale.y);
            }
        }
        else
        {
            _condition = Condition.Stop;
        }
    }

}