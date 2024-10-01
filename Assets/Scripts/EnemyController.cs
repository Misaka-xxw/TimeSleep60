using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
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

    // 敌人的生命值
    public float health=100f;
    public int addNum=0,modNum = 1,lowerNum=0;
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanCreate(int level)
    {
        if (level < lowerNum)
            return false;
        return ((level + addNum) % modNum == 0);
    }

    public void Move(float goalX,float goalY)
    {
        
    }
}
