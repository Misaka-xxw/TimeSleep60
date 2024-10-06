using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Factors : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxExperienceMultify;
    public int maxExperienceAdd;
    public int enemyCoinMultify;
    public int enemyCoinAdd;
    public int enemyExperienceMultify;
    public int enemyExperienceAdd;
    public long LevelExperience(int n)
    {
        return n * n * n * maxExperienceMultify + maxExperienceAdd;
    }
    public int EnemyCoin(int n)
    {
        return n*n * enemyCoinMultify + enemyCoinAdd;
    }
    public int EnemyExperience(int n)
    {
        return n*n * enemyExperienceMultify + enemyExperienceAdd;
    }
}
