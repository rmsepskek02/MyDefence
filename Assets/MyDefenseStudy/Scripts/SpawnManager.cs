using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject startPoint;
    public TextMeshProUGUI timerText;
    Vector3 spawnPoint = new Vector3();
    public float timerTime = 5f;   // 타이머 시간
    float roundDelay = 5f;  // 라운드 딜레이 시간
    float spawnDelay = 1f;  // 스폰 딜레이 시간
    int spawnCount = 1;     // 첫 스폰 개체 수
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = startPoint.transform.position;
        StartCoroutine(DelayForSpawn(spawnDelay, spawnCount));
    }

    // Update is called once per frame
    void Update()
    {

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
    IEnumerator DelayForSpawn(float _spawndelay, int _spawncount)
    {
        for (var i = 0; i < _spawncount; i++)
        {
            // Enemy 생성
            Instantiate(enemyObj, spawnPoint, Quaternion.identity);
            // 스폰 딜레이
            yield return new WaitForSeconds(_spawndelay);
        }
        // 라운드 딜레이 코루틴
        StartCoroutine(DelayForRound(roundDelay, timerTime));
    }

    // 라운드 딜레이 코루틴
    IEnumerator DelayForRound(float _roundDelay, float _timerTime)
    {
        // 타이머 코루틴
        StartCoroutine(CheckTimer(_timerTime));
        // 라운드 딜레이
        yield return new WaitForSeconds(_roundDelay);
        // 개채 생성 수 증가
        spawnCount++;
        // 다음 라운드 시작, 스폰 딜레이 코루틴
        StartCoroutine(DelayForSpawn(spawnDelay, spawnCount));
    }
}
