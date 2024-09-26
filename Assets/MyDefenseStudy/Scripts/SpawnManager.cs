using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Wave[] waves;
    public GameObject enemyObj;
    public GameObject startPoint;
    public TextMeshProUGUI timerText;
    Vector3 spawnPoint = new Vector3();
    public float timerTime = 5f;   // 타이머 시간
    float roundDelay = 5f;  // 라운드 딜레이 시간
    float spawnDelay = 1f;  // 스폰 딜레이 시간
    int spawnCount = 0;     // 첫 스폰 개체 수
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = startPoint.transform.position;
        //StartCoroutine(DelayForRound(roundDelay, timerTime));
    }

    // Update is called once per frame
    void Update()
    {
        SpawnForRound(timerTime);
    }

    // 타이머 코루틴
    IEnumerator CheckTimer(float _time)
    {
        // 타이머 시간 설정
        float timer = _time;
        // timer 초기화
        float time = 0f;

        while (time < timer)
        {
            // 경과된 시간을 누적
            time += Time.deltaTime;
            // UI 업데이트
            timerText.text = Mathf.RoundToInt(timer - time).ToString();
            yield return null;
        }
    }

    // 스폰 딜레이 코루틴
    IEnumerator DelayForSpawn()
    {
        Wave currentWave = waves[PlayerStats.Round - 1];
        // 라운드 딜레이
        yield return new WaitForSeconds(roundDelay);

        for (var i = 0; i < currentWave.enemyCount; i++)
        {
            // Enemy 생성
            GameObject go = Instantiate(currentWave.enemyPrefab, spawnPoint, Quaternion.identity);

            int num = Random.Range(0, 1000);
            go.name = go.name + num;
            // 스폰 딜레이
            yield return new WaitForSeconds(currentWave.spawnDelay);
        }
    }

    // Wave 개수에 따른 라운드 시작
    void SpawnForRound(float _timerTime)
    {
        if (PlayerStats.Round >= 5)
        {
            Debug.Log("LEVEL CLEAR");
            return;
        }

        if (PlayerStats.Wave > 0)
            return;
        // 개채 생성 수 증가
        spawnCount++;
        PlayerStats.IncreaseRound();
        PlayerStats.SetWave(spawnCount);
        // 타이머 코루틴
        StartCoroutine(CheckTimer(_timerTime));
        // 다음 라운드 시작, 스폰 딜레이 코루틴
        StartCoroutine(DelayForSpawn());
    }
}

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;  // 생성할 적의 프리팹
    public int enemyCount;          // 적의 수
    public float spawnDelay;        // 적 생성 지연 시간
}