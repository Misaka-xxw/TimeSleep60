using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 控制主角的脚本
public class PlayerController : Creature
{
    // 猫娘上限
    public float catGirlUpperLimit=100f;
    // 猫娘自愈力
    public float catGirlHealingSpeed=1f;
    private float _catGirlHealth;
    public BarSlider smallSpiritBar, bigHealthBar, bigSpiritBar;
    private void Start()
    {
        _catGirlHealth = catGirlUpperLimit;
        _transform = GetComponent<Transform>();
        moveController = GetComponent<MoveThing>();
        lifeController = GetComponent<LifeThing>();
        attackController = GetComponent<AttackThing>();
        
    }

    private void Update()
    {
        smallSpiritBar.UpdateSlider(_catGirlHealth,catGirlUpperLimit);
        bigSpiritBar.UpdateSlider(_catGirlHealth,catGirlUpperLimit);
        bigHealthBar.UpdateSlider(lifeController.health,lifeController.upperLimit);
        moveController.KeyMove();
    }
}