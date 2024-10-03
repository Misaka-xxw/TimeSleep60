using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScriptParent : MonoBehaviour
{
    public GameController gameController;

    public void SetGameController(GameController g)
    {
        gameController = g;
    }

    public void SetGameController()
    {
        if (gameController != null)
            return;
        var obj = GameObject.FindWithTag("GameController");
        gameController = obj.GetComponent<GameController>();
    }
}