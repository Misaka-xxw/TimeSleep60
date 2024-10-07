using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : ScriptParent
{
    // Start is called before the first frame update
    public Slider timeBar;
    public Text timeText;
    public UiTextBlink startProgramText;
    public List<GameObject> layouts;
    private int _layoutVisble=0;
    public GameObject buttons;
    // 死亡
    public GameObject blueScreen;
    public Text blueRound, blueExperience;
    // 经验和金币
    public Text experienceText,coinText;
    public BarSlider experienceBar;
    
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
    public void Mode0()//开始战斗
    {
        buttons.SetActive(false);
        layouts[_layoutVisble].SetActive(false);
        StartCoroutine(Mode0IE());
    }

    private IEnumerator Mode0IE()
    {
        startProgramText.changeText($"Round {gameController.round}");
        yield return StartCoroutine(startProgramText.Blink(0.4f));
        startProgramText.changeText("3");
        yield return StartCoroutine(startProgramText.Blink(1f));
        startProgramText.changeText("2");
        yield return StartCoroutine(startProgramText.Blink(1f));
        startProgramText.changeText("1");
        yield return StartCoroutine(startProgramText.Blink(1f));
        startProgramText.changeText("GO!!!!!");
        yield return StartCoroutine(startProgramText.Blink(1f));
        StartCoroutine(startProgramText.Blink(0f, false));
        gameController.NextMode();
    }
    //战斗进行中
    public void Mode1()//战斗
    {
        gameController.NextMode();
    }
    //战斗中期结算
    public void Mode2()//结束战斗
    {
        StartCoroutine(Mode0IE());
    }
    private IEnumerator Mode2IE()
    {
        startProgramText.changeText("time.sleep(60)");
        yield return StartCoroutine(startProgramText.Blink(1f));
    }
    // time.sleep(60)
    public void Mode3()//休息
    {
        buttons.SetActive(true);
        _layoutVisble = 0;
        LayoutButtonClick(0);
    }

    public void LayoutButtonClick(int n)
    {
        // if(layouts[_layoutVisble])
        layouts[_layoutVisble].SetActive(false);
        layouts[n].SetActive(true);
        _layoutVisble = n;
    }

    public void BlueScreen()
    {
        long experience = gameController.experience;
        for (int i = 1; i < gameController.level; ++i)
        {
            experience += gameController.GetMaxExperience(i);
        }
        blueScreen.SetActive(true);
        blueRound.text = $"{gameController.round}";
        blueExperience.text = $"{experience}";
    }

    public void UpdateExperience()
    {
        experienceText.text = $"{gameController.experience}/{gameController.maxexperience}";
        experienceBar.UpdateSlider(gameController.experience,gameController.maxexperience);
    }

    public void UpdateCoin()
    {
        coinText.text = $"{gameController.coins}";
    }
}
