using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// 发射子弹者
public class AttackLauncher : AttackInfo
{
    public List<GameObject> bullets;

    private float _frozenTime = 0f, _nextShootTime = 0f;

    private void Start()
    {
        _nextShootTime = 1f / attackSpeed;
        SetGameController();
    }

    void Update()
    {
        if (gameController.GetMode() == 1)
        {
            _frozenTime += Time.deltaTime;
            if (_frozenTime >= _nextShootTime)
            {
                _frozenTime = 0f;
                Shoot();
            }
        }
    }

    public IEnumerator StartShoot()
    {
        while (true)
        {
            yield return new WaitUntil(() => gameController.GetMode() == 1);
            Shoot();
            yield return new WaitForSeconds(1f/attackSpeed);
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bullets[Random.Range(0, bullets.Count)], this.transform.position,
            Quaternion.identity);
        var (x, y) = gameController.FindGoal(this.transform.position.x, this.transform.position.y, this.tag);
        MoveThing move = bullet.GetComponent<MoveThing>();
        if (move == null)
            return;
        move.StartMove2SomeWhere(x, y);
    }
}