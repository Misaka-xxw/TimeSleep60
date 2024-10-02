using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class AttackLauncher : AttackInfo
{
    public List<GameObject> bullets;

    private float _frozenTime = 0f, _nextShootTime = 0f;

    private void Start()
    {
        _nextShootTime = 1f / attackSpeed;
    }

    void Update()
    {
        _frozenTime += Time.deltaTime;
        if (_frozenTime >= _nextShootTime)
        {
            _frozenTime = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bullets[Random.Range(0, bullets.Count)], this.transform.position,
            Quaternion.identity);
        if (bullet == null)
            return;
        var (x,y)=gameController.FindGoal(this.transform.position.x, this.transform.position.y, this.tag);
        MoveThing move = bullet.GetComponent<MoveThing>();
        if (move == null)
            return;
        move.StartMove2SomeWhere(x,y);
    }
}