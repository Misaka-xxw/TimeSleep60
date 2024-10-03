using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : ScriptParent
{
    // Start is called before the first frame update
    public Slider timeBar;
    public Text timeText;
    public UiTextBlink startProgramText, endProgramText;
    private void Start()
    {
        gameController = GetComponent<GameController>();
    }

    public void SetTime(int t)
    {
        timeBar.value = t;
        timeText.text = $"{t}";
    }
    //战斗进行时
    public void Mode0()
    {
        StartCoroutine(Mode0IE());
    }

    private IEnumerator Mode0IE()
    {
        yield return StartCoroutine(startProgramText.Blink());
        gameController.NextMode();
    }
    //战斗进行中
    public void Mode1()
    {
        gameController.NextMode();
    }
    //战斗中期结算
    public void Mode2()
    {
        gameController.NextMode();
    }
    // time.sleep(60)
    public void Mode3()
    {
        gameController.NextMode();
    }
}
