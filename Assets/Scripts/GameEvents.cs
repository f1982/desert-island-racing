using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // singlone instance
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onRewardCollect;
    public void rewardCollect(int score)
    {
        if (onRewardCollect != null)
        {
            onRewardCollect(score);
        }
    }

    public event Action onTimeoutTrigger;
    public void TimeoutTrigger()
    {
        if (onTimeoutTrigger != null)
        {
            onTimeoutTrigger();
        }
    }
}

