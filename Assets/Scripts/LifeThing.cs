using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// 有生命值的东西
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
    public Dead dead;
    public bool isPlayer = false;
    public bool isEnemy = false;
    public bool isAlive = true;
    
    void Start()
    {
        health = upperLimit;
        if (visibleHealthBar)
        {
            _bar = Instantiate(healthBar, transform.position, Quaternion.identity);
            _bar.transform.position = this.transform.position;
            _bar.transform.parent = this.transform;
            _barSlider = _bar.GetComponent<BarSlider>();
            _barSlider.UpdateSlider(health, upperLimit);
            // uiTracker.spriteToTrack = this.gameObject.transform;
        }
    }

    public void BeAttacked(float force, string buff)
    {
        if (health <= 0)
        {
            return;
        }
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
            _barSlider.UpdateSlider(health, upperLimit);
        }

        if (health <= 0)
        {
            StartCoroutine(this.Die());
        }
    }

    private IEnumerator Die()
    {
        isAlive = false;
        yield return new WaitForSeconds(1);//模拟动画结束
        if (isPlayer)
        {
            Time.timeScale = 0f; //后面切换成失败结算
            gameController.gameOver = true;
        }

        Destroy(this.gameObject);
        yield break;
    }


    public IEnumerator SelfHeal()
    {
        while (true)
        {
            if (health <= 0)
            {
                yield break;
            }

            if (health + 1f < upperLimit)
            {
                health += 1f;
                _barSlider.UpdateSlider(health, upperLimit);
            }

            yield return new WaitForSeconds(1f / healingSpeed);
        }
    }
}