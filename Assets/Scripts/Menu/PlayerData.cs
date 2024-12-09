using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float playerStats;
    public float[] playerPositionAndRotation;

    public PlayerData(float _playerStats, float[] _playerPositionAndRotation)
    {
        playerStats = _playerStats;
        playerPositionAndRotation = _playerPositionAndRotation;
    }
}
