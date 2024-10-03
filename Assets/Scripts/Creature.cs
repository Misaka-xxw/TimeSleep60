using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 生物基类（包括硅基生物和赛博生物）的虚基类，包括移动，攻击，生命
public abstract class Creature : MonoBehaviour
{
    protected Transform _transform;

    public MoveThing moveController;

    public LifeThing lifeController;

    public AttackThing attackController;
    // public abstract void Appear();
    // public abstract void Die();
}