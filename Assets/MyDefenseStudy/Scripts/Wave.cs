using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;  // 생성할 적의 프리팹
    public int enemyCount;          // 적의 수
    public float spawnDelay;        // 적 생성 지연 시간
}