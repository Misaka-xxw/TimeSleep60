using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private float _timeCounter;

    //模式，0为马上开始program，1为program，2为马上开始sleep，3为sleep
    private int _mode;
    
    void Start()
    {
        _timeCounter = 0f;
        _mode = 1;
        _catGirlTransform = catGirl.GetComponent<Transform>();
        StartCoroutine(EnemyCreate());
    }

    // Update is called once per frame
    void Update()
    {
        _timeCounter += Time.deltaTime;
        switch (_mode)
        {
            case 0: break;
            case 1:
                float x = _catGirlTransform.position.x, y = _catGirlTransform.transform.position.y;
                foreach (var enemy in enemies)
                {
                    var enemyController = enemy.GetComponent<EnemyController>();
                    if (enemyController != null)
                    {
                        enemyController.Move(x, y);
                    }
                }

                break;
            case 2: break;
            case 3: break;
            default:
                break;
        }
    }

    public (float, float) FindGoal(float x, float y, string sTag)
    {
        float farDistance = 20000000f, resX = 0f, resY = 0f;
        if (sTag == "Player" || sTag == "Teammate")
        {
            foreach (var enemy in enemies)
            {
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

        if (farDistance == 0)
            return (0, 0);
        farDistance = (float)Math.Sqrt(farDistance);
        return (resX / farDistance, resY/ farDistance);
    }

    private IEnumerator EnemyCreate()
    {
        while (true)
        {
            if (_mode != 1)
            {
                yield return null;
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
                default:
                    break;
            }

            GameObject cloneEnemy = Instantiate(allEnemies[randomIndex], v2, Quaternion.identity);
            enemies.Add(cloneEnemy);
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}