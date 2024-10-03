using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// 子弹或者进程攻击
public abstract class AttackThing : AttackInfo
{
    void Start()
    {
        buffs.Add("");
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.tag);
        foreach (var attackedTag in attackedTags)
        {
            if (other.CompareTag(attackedTag))
            {
                LifeThing lifeThing = other.GetComponent<LifeThing>();
                if (lifeThing != null)
                {
                    lifeThing.BeAttacked(AttackForce(),buffs[Random.Range(0,buffs.Count)]);
                }
            }
        }
    }

    private float AttackForce()
    {
        float res = attackPower*Random.Range(0.9f,1.1f)*multiFactor;
        if (Random.Range(0f, 1f) <= criticalRate)
        {
            res += criticalDamage * Random.Range(0.9f, 1.1f) * Random.Range(1.1f, 2.5f);
        }

        return res;
    }
}