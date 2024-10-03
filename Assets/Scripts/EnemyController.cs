using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敌人
public class EnemyController : Creature
{
    // Start is called before the first frame update
    public int addNum=0,modNum = 1,lowerNum=0;
    
    void Start()
    {
        _transform = GetComponent<Transform>();
        moveController = GetComponent<MoveThing>();
        lifeController = GetComponent<LifeThing>();
        attackController = GetComponent<AttackThing>();
    }
    
    public bool CanCreate(int level)
    {
        if (level < lowerNum)
            return false;
        return ((level + addNum) % modNum == 0);
    }
    // 移动
    public void Move(float x,float y)
    {
        moveController.Move(x,y);
    }
}
