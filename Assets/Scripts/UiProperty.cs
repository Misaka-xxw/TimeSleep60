using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiProperty : MonoBehaviour
{
    public List<Text> texts;
    public void UpdateText(string s,int n)
    {
        if (n >= texts.Count)
        {
            texts[n].text = s;
        }
    }
}
/*
|等级|Level| 
|经验|Experience| 
| 攻击力|AttackPower | 猫娘的攻击力，可以影响到队友的攻击力
| 攻击速度|AttackSpeed |
| 暴击率|CriticalRate |
| 暴击伤害|CriticalDamage |
| 移动速度|MovementSpeed |
| 防御力|Defense | 猫娘和程序防御力用同一个得了
| 程序上限|ProgramUpperLimit | 
| 程序自愈力|ProgramHealingSpeed | 就是程序恢复速度
| 猫娘上限|CatGirlUpperLimit | 
| 猫娘自愈力|CatGirlHealingSpeed | 就是猫娘精神力恢复速度，一开始就比程序强多了
| 队友数量|TeammateNumber | 
*/