using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 死亡，应该先播死亡动画再死
public class Dead : ScriptParent
{
    public Animator animator;

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(2);//填充死亡动画
    }
}
/*
NullReferenceException: Object reference not set to an instance of an object
LifeThing+<Die>d__15.MoveNext () (at Assets/Scripts/LifeThing.cs:75)
UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) (at <779cc116a5954f1c9b92496e62345641>:0)
UnityEngine.MonoBehaviour:StartCoroutine(IEnumerator)
LifeThing:BeAttacked(Single, String) (at Assets/Scripts/LifeThing.cs:69)
AttackThing:OnTriggerEnter2D(Collider2D) (at Assets/Scripts/AttackThing.cs:24)


 */
