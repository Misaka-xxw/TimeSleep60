using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LifeThing : ScriptParent
{
    // Start is called before the first frame update
    // 绑定角色
    public Creature creature;

    public float health;

    // 防御力
    public float defense = 1f;

    // 血量上限
    public float upperLimit = 100f;

    // 自愈力
    public float healingSpeed = 1f;

    //是否生成血条
    public bool visibleHealthBar = true;

    //血条
    public GameObject healthBar;
    public UITracker uiTracker;
    private GameObject _bar;
    private BarSlider _barSlider;
    void Start()
    {
        health = upperLimit;
        if (visibleHealthBar)
        {
            _bar = Instantiate(healthBar,transform.position,Quaternion.identity);
            _bar.transform.position = this.transform.position;
            _bar.transform.parent = this.transform;
            _barSlider = _bar.GetComponent<BarSlider>();
            _barSlider.UpdateSlider(health,upperLimit);
            uiTracker.spriteToTrack = this.gameObject.transform;
        }
    }
    public void BeAttacked(float force, string buff)
    {
        float baseHurt = force / (defense + 1f);
        switch (buff)
        {
            case "":
                health -= baseHurt;
                break;
            case "half":
                health /= 2;
                break;
            default:
                health -= baseHurt;
                break;
        }

        if (visibleHealthBar)
        {
            _barSlider.UpdateSlider(health,upperLimit);
        }
        
    }
}