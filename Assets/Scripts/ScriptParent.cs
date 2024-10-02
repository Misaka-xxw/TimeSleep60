using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptParent : MonoBehaviour
{
    protected GameController gameController;
    public void SetGameController(GameController g)
    {
        gameController = g;
    }
}