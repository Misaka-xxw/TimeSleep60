using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 移动是否水平翻转
public class MoveAnimate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform girlTransform;
    public LifeThing lifeThing;
    public float downV, upV;
    public Animator animator;
    private bool isMoving = false, isLeft = true;

    void Start()
    {
        girlTransform = GetComponent<Transform>();
        lifeThing = GetComponent<LifeThing>();
        animator = GetComponent<Animator>();
        if (lifeThing == null)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!lifeThing.isAlive)
        {
            Destroy(this); //去掉这个组件
        }

        var x = Input.GetAxis("Horizontal");
        if (x < downV)
        {
            if (!isLeft)
            {
                girlTransform.localScale =
                    new Vector3(Math.Abs(girlTransform.localScale.x), girlTransform.localScale.y);
                isLeft = true;
            }

            if (!isMoving)
            {
                animator.SetTrigger("move");
                isMoving = true;
            }
        }

        else if (x > upV)
        {
            if (isLeft)
            {
                girlTransform.localScale =
                    new Vector3(-Math.Abs(girlTransform.localScale.x), girlTransform.localScale.y);
                isLeft = false;
            }

            if (!isMoving)
            {
                animator.SetTrigger("move");
                isMoving = true;
            }
        }
        else
        {
            var y = Input.GetAxis("Vertical");
            if (y < downV || y > upV)
            {
                if (!isMoving)
                {
                    animator.SetTrigger("move");
                    isMoving = true;
                }
            }
            else
            {
                if (isMoving)
                {
                    animator.SetTrigger("stop");
                    isMoving = false;
                }
            }
        }
    }
}