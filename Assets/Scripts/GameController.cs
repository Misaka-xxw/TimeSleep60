using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = System.Numerics.Vector3;

// 游戏控制，包括记录游戏阶段，等等
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //玩家
    public GameObject catGirl;

    //所有队友图鉴
    public List<GameObject> allTeammates;

    //队友列表
    public List<GameObject> teammates;

    // 所有敌人图鉴
    public List<GameObject> allEnemies;

    //敌人列表
    public List<GameObject> enemies;

    // 队友数量
    public int teammateNumber = 0;

    // 金币数量
    public int coins = 0;

    //生成敌人的地标坐标
    public float landmarks = 17f;
    private Transform _catGirlTransform;

    //计时器
    private int _timeCounter;

    //模式，0为马上开始program，1为program，2为结束program马上开始sleep，3为sleep
    private int _mode;
    //UI切换
    public UiController uiController;
    public bool gameOver = false;
    // 等级
    public int level = 1;
    // 经验
    public long experience=0;
    public long maxexperience;
    //游戏轮次
    public int round = 1;
    //debug轮次
    public int debugMode;
    //主角introduction
    public Introduction introduction;
    //换算因子和公式
    public Factors factors;
    // 金币预制体
    public GameObject coin;
    public AudioManager audioManager;
    void Start()
    {
        UpdateExperience(0);
        gameOver = false;
        _mode = debugMode;
        _catGirlTransform = catGirl.GetComponent<Transform>();
        round = 1;
        StartCoroutine(GameRun());
    }
    
    //移动敌人和自己
    private IEnumerator MoveAll()
    {
        while (true)
        {
            if(_mode!=1||gameOver)
                yield break;
            enemies = enemies.Where(item => item!= null).ToList();
            float x = _catGirlTransform.position.x, y = _catGirlTransform.transform.position.y;
            foreach (var enemy in enemies)
            {
                var enemyController = enemy.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.Move(x, y);
                }
            }
            yield return null;
        }
    }
    private IEnumerator GameRun()
    {
        while (true)
        {
            //------------------------------------------
            //0:新一轮的开始准备
            uiController.Mode0();
            yield return new WaitUntil(()=>_mode==1);
            //------------------------------------------
            //1:新一轮战斗
            // uiController.Mode1();
            audioManager.PlayBgm1Min();
            Debug.Log(_mode);
            StartCoroutine(CountDown());
            StartCoroutine(EnemyCreate());
            StartCoroutine(MoveAll());
            yield return new WaitUntil(()=>_mode==2||gameOver);
            //------------------------------------------
            //2:过渡
            if (gameOver)
            {
                yield break;
            }
            uiController.Mode2();
            //结束过渡
            yield return new WaitUntil(()=>_mode==3);
            //------------------------------------------
            //3:休息
            audioManager.PlayBgm1Min();
            StartCoroutine(CountDown());
            uiController.Mode3();
            //time.sleep(60),升级和购买队友
            yield return new WaitUntil(()=>_mode==0);
            ++round;

        }
    }

    private IEnumerator CountDown()
    {
        _timeCounter = 60;
        uiController.SetTime(_timeCounter);
        int mode = _mode;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            _timeCounter -= 1;
            uiController.SetTime(_timeCounter);
            if (gameOver||mode!=_mode)
            {
                yield break;
            }
            if (_timeCounter == 0)
            {
                NextMode();
                yield break;   
            }
        }
    }
    public (float, float) FindGoal(float x, float y, string sTag)
    {
        float farDistance = 20000000f, resX = 0f, resY = 0f;
        if (sTag == "Player" || sTag == "Teammate")
        {
            enemies = enemies.Where(item => item!= null).ToList();
            foreach (var enemy in enemies)
            {
                LifeThing lifeThing = enemy.GetComponent<LifeThing>();
                if (lifeThing == null || lifeThing.isAlive == false)
                {
                    continue;
                }
                
                float x1 = enemy.transform.position.x-x, y1 = enemy.transform.position.y-y;
                float newDistance = (float)(Math.Pow(x1, 2) +
                                            Math.Pow(y1, 2));
                if (newDistance < farDistance)
                {
                    farDistance = newDistance;
                    resX = x1;
                    resY = y1;
                }
            }
        }
        else if (sTag == "Enemy")
        {
            float x1 = catGirl.transform.position.x-x, y1 = catGirl.transform.position.y-y;
            float newDistance = x1 * x1 + y1 * y1;
            if (newDistance < farDistance)
            {
                farDistance = newDistance;
                resX = x1;
                resY = y1;
            }
            foreach (var enemy in teammates)
            {
                LifeThing lifeThing = enemy.GetComponent<LifeThing>();
                if (lifeThing == null || lifeThing.isAlive == false)
                {
                    continue;
                }
                x1 = enemy.transform.position.x - x;
                y1 = enemy.transform.position.y-y;
                newDistance = x1 * x1 + y1 * y1;
                if (newDistance < farDistance)
                {
                    farDistance = newDistance;
                    resX = x1;
                    resY = y1;
                }
            }
        }
        if (farDistance == 0)
            return (0, 0);
        farDistance = (float)Math.Sqrt(farDistance);
        return (resX / farDistance, resY/ farDistance);
    }

    private IEnumerator EnemyCreate()
    {
        while (true)
        {
            if (_mode!=1)
            {
                yield break;
            }
            int randomIndex = Random.Range(0, allEnemies.Count);
            int horizonVertical = Random.Range(0, 4);
            Vector2 v2 = Vector2.zero;
            switch (horizonVertical)
            {
                case 0:
                    v2.x = landmarks;
                    v2.y = Random.Range(-landmarks, landmarks);
                    break;
                case 1:
                    v2.x = -landmarks;
                    v2.y = Random.Range(-landmarks, landmarks);
                    break;
                case 2:
                    v2.y = landmarks;
                    v2.x = Random.Range(-landmarks, landmarks);
                    break;
                case 3:
                    v2.y = -landmarks;
                    v2.x = Random.Range(-landmarks, landmarks);
                    break;
            }
            GameObject cloneEnemy = Instantiate(allEnemies[randomIndex], v2, Quaternion.identity);
            enemies.Add(cloneEnemy);
            yield return new WaitForSeconds(Random.Range(2, 6));
        }
    }

    public void NextMode()
    {
        _mode = (_mode + 1) % 4;
        _timeCounter = 60;
    }

    public int GetMode()
    {
        return _mode;
    }
    public long GetMaxExperience()
    {
        return factors.LevelExperience(level);
    }
    public long GetMaxExperience(int n)
    {
        return factors.LevelExperience(n);
    }
    
    public void UpdateExperience(int n)
    {
        experience += n * round;
        uiController.UpdateExperience();
        while (experience > maxexperience)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        experience -= maxexperience;
        ++level;
        maxexperience = GetMaxExperience();
        UpdateCoin(100);
    }
    public void UpdateCoin(int n)
    {
        coins += n * round;
        uiController.UpdateCoin();
    }

    public void Fail()
    {
        gameOver = true;
        uiController.BlueScreen();
    }

    public void SetCoin(Vector2 pos,int v)
    {
        GameObject cloneCoin = Instantiate(coin, pos, Quaternion.identity);
        Coin value = cloneCoin.GetComponent<Coin>();
        value.values = v;
    }
}