using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : ScriptParent
{
    public Transform goal, me;
    public float xMax, yMax;
    public Camera camera;
    public float smoothTime = 0.2f;
    private Vector3 velocity = Vector3.zero;
    // void Start()
    // {
    //     xMax *= xMax;
    //     yMax *= yMax;
    // }

    void Update()
    {
        if (gameController.GetMode()!= 1)
        {
            return;
        }

        if (goal != null)
        {
            float x = me.position.x,
                y = me.position.y,
                x1 = goal.position.x,
                y1 = goal.position.y;
            // if (Math.Abs(camera.transform.position.x - x1)>=xMax)
            // {
            //     x = x1;
            // }
            // if (Math.Abs(camera.transform.position.y - y1)>=yMax)
            // {
            //     y = y1;
            // }
            
            // me.position = new Vector3(x1, y1);
            me.position = Vector3.SmoothDamp(me.position, new Vector3(x1, y1), ref velocity, smoothTime);
            
            // if (Pow2(camera.transform.position.x - x1) / xMax + Pow2(camera.transform.position.y - y1) / yMax >= 1)
            // {
            //     me.position = new Vector3(x1, y1);
            //     // me.position = Vector3.SmoothDamp(me.position, new Vector3(x1, y1), ref velocity, smoothTime);
            // }
        }
    }

    private float Pow2(float x)
    {
        return x * x;
    }
}