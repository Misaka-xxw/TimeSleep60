using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 死亡，应该先播死亡动画再死
public class Dead : ScriptParent
{
    public Animator animator;
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
