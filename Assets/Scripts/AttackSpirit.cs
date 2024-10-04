using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpirit : ScriptParent
{
    public SpriteRenderer renderer0;

    void Start()
    {
       renderer0 = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    public bool IsVisible()
    {
        
        return renderer0.isVisible;
    }
}
