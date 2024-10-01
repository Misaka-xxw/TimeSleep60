using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject catGirl;//玩家
    public List<GameObject> teammates;//队友列表
    public List<GameObject> enemies;//敌人列表
    private float _timeCounter;
    private short _mode;
    void Start()
    {
        _timeCounter = 0f;
        _mode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timeCounter += Time.deltaTime;
        if (_mode == 0)
        {
            
        }
        else if (_mode == 1)
        {
            
        }
        else
        {
            
        }
    }
}
