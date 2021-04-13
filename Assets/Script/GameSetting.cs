using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LevelData
{
    public float spawnIntervalSec;
    public float scrollSpeed;
    public float holeSize;
}

[CreateAssetMenu (fileName = "GameSetting", menuName = "BirdGame/GameSetting", order = 1)]
public class GameSetting : ScriptableObject
{
    public float jumpPower;
    public LevelData levelData;
}
