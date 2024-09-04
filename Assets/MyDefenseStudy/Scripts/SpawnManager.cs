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
    public float timerTime = 5f;   // Ÿ�̸� �ð�
    float roundDelay = 5f;  // ���� ������ �ð�
    float spawnDelay = 1f;  // ���� ������ �ð�
    int spawnCount = 1;     // ù ���� ��ü ��
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

    // Ÿ�̸� �ڷ�ƾ
    IEnumerator CheckTimer(float _time)
    {
        // Ÿ�̸� �ð� ����
        float timer = _time;
        // timer �ʱ�ȭ
        float time = 0f;

        while (time < timer)
        {
            // ����� �ð��� ����
            time += Time.deltaTime;
            // UI ������Ʈ
            timerText.text = Mathf.RoundToInt(timer - time).ToString();
            yield return null;
        }
    }

    // ���� ������ �ڷ�ƾ
    IEnumerator DelayForSpawn(float _spawndelay, int _spawncount)
    {
        for (var i = 0; i < _spawncount; i++)
        {
            // Enemy ����
            Instantiate(enemyObj, spawnPoint, Quaternion.identity);
            // ���� ������
            yield return new WaitForSeconds(_spawndelay);
        }
        // ���� ������ �ڷ�ƾ
        StartCoroutine(DelayForRound(roundDelay, timerTime));
    }

    // ���� ������ �ڷ�ƾ
    IEnumerator DelayForRound(float _roundDelay, float _timerTime)
    {
        // Ÿ�̸� �ڷ�ƾ
        StartCoroutine(CheckTimer(_timerTime));
        // ���� ������
        yield return new WaitForSeconds(_roundDelay);
        // ��ä ���� �� ����
        spawnCount++;
        // ���� ���� ����, ���� ������ �ڷ�ƾ
        StartCoroutine(DelayForSpawn(spawnDelay, spawnCount));
    }
}
