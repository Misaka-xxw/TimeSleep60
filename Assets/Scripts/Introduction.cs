using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 图鉴介绍
public class Introduction : ScriptParent
{
    // Start is called before the first frame update
    // 属性控制
    public bool inShop;
    public bool isPlayer,isEnemy,isTeammate;
    public bool isBook, isPet,isItemInShop, isItemRandomAppear;
    public string myName,introduction;
    // 等级
    public int level=1;
    // 攻击力
    public float baseAttackPower;
    public float addAttackPower;
    // 攻击速度
    public float baseAttackSpeed;
    public float addAttackSpeed;
    // 暴击率
    public float baseCriticalRate;
    public float addCriticalRate;
    // 暴击伤害
    public float baseCriticalDamage;
    public float addCriticalDamage;
    // 移动速度
    public float baseMovementSpeed;
    public float addMovementSpeed;
    // 防御力
    public float baseDefense;
    public float addDefense;
    // 生命值
    public float health;
    // 程序上限
    public float baseProgramUpperLimit;
    public float addProgramUpperLimit;
    // 程序自愈力
    public float baseProgramHealingSpeed;
    public float addProgramHealingSpeed;
    // 敌人掉落金币（基础），队友购买所需金币（基础）
    public int baseMoney;
    //从这里开始其它人没有，只有玩家有
    // 精神力
    public float catGirlHealth;
    // 猫娘精神力上限
    public float baseCatGirlUpperLimit;
    public float addCatGirlUpperLimit;
    // 猫娘自愈力
    public float baseCatGirlHealingSpeed;
    public float addCatGirlHealingSpeed;
    // 队友数量
    public int teammateNumber;
}
