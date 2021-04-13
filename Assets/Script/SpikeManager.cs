using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public Spike spikePrefab;
    public GameSetting gameSetting;

    private float _birdPosX;
    private LevelData _levelData;

    public void Init()
    {
        _birdPosX = FindObjectOfType<Bird>().transform.position.x;
        _levelData =  gameSetting.levelData;


        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            CreateSpike();
            yield return new WaitForSeconds(_levelData.spawnIntervalSec);
        }
    }

    private void CreateSpike()
    {
        var newSpike = Instantiate(spikePrefab, transform);
        newSpike.transform.position = new Vector3(10f, 0f);
        newSpike.Init(_levelData.holeSize, _levelData.scrollSpeed, _birdPosX);
    }
}
