using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour {

    private float WorldNowTime = 1.0f;

    public float GetTime()
    {
        return WorldNowTime;
    }

    public void SetTime(float settime)
    {
        WorldNowTime = settime;
    }
}
