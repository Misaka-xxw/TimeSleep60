using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 控制主角的脚本
public class PlayerController : MonoBehaviour
{
    // 等级
    public int level = 1;
    // 经验
    public float experience = 0f;
    // 攻击力
    public float atackPower = 10f;

    // 攻击速度
    public float atackSpeed=1f;

    // 暴击伤害
    public float criticalDamage=1f;

    // 暴击率
    public float criticalRate=0.02f;

    // 移动速度
    public float movementSpeed=0.1f;

    // 防御力
    public float defense=1f;

    // 程序上限
    public float programUpperLimit=100f;

    // 程序自愈力
    public float programHealingSpeed=1f;

    // 猫娘上限
    public float catGirlUpperLimit=100f;

    // 猫娘自愈力
    public float catGirlHealingSpeed=1f;

    // 队友数量
    public int teammateNumber=0;

    public bool canMove = true;
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (!canMove)//动不了
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * movementSpeed;//获取左右按键输入
        var y = Input.GetAxis("Vertical") * movementSpeed;//获取上下按键输入
        var movement = new Vector2(_transform.position.x+x, _transform.position.y+y);
        _transform.position = movement;
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