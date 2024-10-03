using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

// 移动的东西
public class MoveThing : MonoBehaviour
{
    // 移动速度
    public float baseMovementSpeed = 1f, movementSpeed = 1f;

    //是否可以移动，固定属性
    public bool canMove = true;

    //移动
    public Transform moveTransform;
    public float downLimit=1f, upLimit;
    void Start()
    {
        if(moveTransform==null)
            moveTransform = GetComponent<Transform>();
    }

    // 向目标移动
    public void Move(float goalX, float goalY)
    {
        if (!canMove)
            return;
        float x = moveTransform.position.x, y = moveTransform.position.y;
        float dx = (goalX - x), dy = (goalY - y), xy = (float)Math.Sqrt(dx * dx + dy * dy);
        if (xy <= downLimit)
            return;
        if (xy == 0)
            return;
        moveTransform.position = new Vector3(x + dx / xy * movementSpeed * Time.deltaTime,
            y + dy / xy * movementSpeed * Time.deltaTime);
    }
    
    // 按键移动
    public void KeyMove()
    {
        if (!canMove) //动不了
        {
            return;
        }
        var x = Input.GetAxis("Horizontal"); //获取左右按键输入
        var y = Input.GetAxis("Vertical"); //获取上下按键输入
        var xy = (float)Math.Sqrt(x * x + y * y);
        if (xy == 0)
        {
            return;
        }

        var movement = new Vector2(moveTransform.position.x + x / xy * movementSpeed * Time.deltaTime,
            moveTransform.position.y + y / xy * movementSpeed * Time.deltaTime);
        moveTransform.position = movement;
    }

    // 直线移动
    public void StartMove2SomeWhere(float x,float y)
    {
        moveTransform = GetComponent<Transform>();
        if (moveTransform == null)
        {
            this.AddComponent<Transform>();
            moveTransform = GetComponent<Transform>();
        }
        StartCoroutine(Move2SomeWhere(x, y));
    }
    private IEnumerator Move2SomeWhere(float x,float y)
    {
        while (true)
        {
            var v2 = new Vector2(moveTransform.position.x+x*movementSpeed*Time.deltaTime,moveTransform.position.y+y*movementSpeed*Time.deltaTime);
            moveTransform.position = v2;
            yield return null;
        }
    }
}