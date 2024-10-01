using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    //玩家
    public GameObject catGirl;
    //所有队友列表
    public List<GameObject> allTeammates;
    //队友列表
    public List<GameObject> teammates;
    // 所有敌人的列表
    public List<GameObject> allEnemies;
    //敌人列表
    public List<GameObject> enemies;

    //生成敌人的地标坐标
    public float landmarks=17f;

    //计时器
    private float _timeCounter;

    //模式，0为马上开始program，1为program，2为马上开始sleep，3为sleep
    private int _mode;

    void Start()
    {
        _timeCounter = 0f;
        _mode = 1;
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
                float x=catGirl.transform.position.x,y=catGirl.transform.position.x;
                for (int i = 0; i < enemies.Count; i++)
                {
                    EnemyController enemyController= enemies[i].GetComponent<EnemyController>();
                    if (enemyController != null)
                    {
                        enemyController.Move(x,y);
                    }

                    // enemies.Remove(i);
                }
                break;
            case 2: break;
            case 3: break;
            default:
                break;
        }
    }
    private IEnumerator EnemyCreate()
    {
        while (true)
        {
            if (_mode!=1)
            {
                yield return new WaitForSeconds(_mode==3?60:5);
            }
            int randomIndex = Random.Range(0, allEnemies.Count);
            int horizonVertical = Random.Range(0, 4);
            Vector2 v2=Vector2.zero;
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
            Debug.Log(horizonVertical);
            Debug.Log(v2);
            GameObject cloneEnemy = Instantiate(allEnemies[randomIndex], v2, Quaternion.identity);
            allEnemies.Add(cloneEnemy);
            yield return new WaitForSeconds(Random.Range(1,5));
        }
    }
}