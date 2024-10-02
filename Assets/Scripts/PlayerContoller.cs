using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制主角的脚本
public class PlayerController : Creature
{
    // 等级
    public int level = 1;
    // 经验
    public float experience = 0f;
    // 猫娘上限
    public float catGirlUpperLimit=100f;
    // 猫娘自愈力
    public float catGirlHealingSpeed=1f;
    
    
    

    private void Start()
    {
        _transform = GetComponent<Transform>();
        moveController = GetComponent<MoveThing>();
        lifeController = GetComponent<LifeThing>();
        attackController = GetComponent<AttackThing>();
    }

    private void Update()
    {
        moveController.KeyMove();
    }

    
//碰到了Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     
        // }
    }

//碰到了Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}