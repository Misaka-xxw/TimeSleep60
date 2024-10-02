using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    protected Transform _transform;

    public MoveThing moveController;

    public LifeThing lifeController;

    public AttackThing attackController;
    // public abstract void Appear();
    // public abstract void Die();
}