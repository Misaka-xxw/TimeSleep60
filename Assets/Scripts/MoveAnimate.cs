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
    public Animator animator;
    private Condition _condition=Condition.Stop;
    
    void Start()
    {
        girlTransform = GetComponent<Transform>();
        lifeThing = GetComponent<LifeThing>();
        animator = GetComponent<Animator>();
        if(lifeThing==null)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!lifeThing.isAlive )
        {
            Destroy(this);//去掉这个组件
        }
        var x = Input.GetAxis("Horizontal");
        if (x < downV)
        {
            switch (_condition)
            {
                case Condition.RightMove:
                    _condition = Condition.LeftMove;
                    girlTransform.localScale=new Vector3(Math.Abs(girlTransform.localScale.x),girlTransform.localScale.y);
                    break;
                case Condition.Stop:
                    _condition = Condition.LeftMove;
                    animator.SetTrigger("move");
                    girlTransform.localScale=new Vector3(Math.Abs(girlTransform.localScale.x),girlTransform.localScale.y);
                    break;
                default:
                    break;
            }
        }
        
        else if (x>upV)
        {
            switch (_condition)
            {
                case Condition.LeftMove:
                    _condition = Condition.RightMove;
                    girlTransform.localScale=new Vector3(-Math.Abs(girlTransform.localScale.x),girlTransform.localScale.y);
                    break;
                case Condition.Stop:
                    _condition = Condition.RightMove;
                    animator.SetTrigger("move");
                    girlTransform.localScale=new Vector3(-Math.Abs(girlTransform.localScale.x),girlTransform.localScale.y);
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (_condition != Condition.Stop)
            {
                var y = Input.GetAxis("Vertical");
                if (y > downV && y < upV)
                {
                    _condition = Condition.Stop;
                    animator.SetTrigger("stop");
                }
            }
        }
    }

}