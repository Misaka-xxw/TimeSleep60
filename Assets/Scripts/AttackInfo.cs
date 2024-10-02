using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameController gameController;
    // 攻击力
    public float attackPower = 10f;

    // 攻击速度
    public float attackSpeed = 1f;

    // 暴击伤害
    public float criticalDamage = 10f;

    // 暴击率
    public float criticalRate = 0.02f;
    
    // 攻击目标
    public List<string> attackedTags;
    // 攻击buff
    public List<string> buffs;
    // 攻击系数
    public float multiFactor = 1f;
}
