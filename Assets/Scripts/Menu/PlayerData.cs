using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float playerStats;
    public float[] playerPositionAndRotation;
    public string[] inventoryContent;

    public PlayerData(float _playerStats, float[] _playerPositionAndRotation, string[] _inventoryContent)
    {
        playerStats = _playerStats;
        playerPositionAndRotation = _playerPositionAndRotation;
        inventoryContent = _inventoryContent;
    }
}
