using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyDefence
{
    //Enemy ������ �����ϴ� Ŭ����
    public class SpawnManager : MonoBehaviour
    {
        //�ʵ�
        #region Variable
        //enemy ������
        public GameObject enemyPrefab;
        //���� ��ġ(���� ��ġ)
        public Transform startPoint;

        //���� Ÿ�̸�
        public float spawnTimer = 5f;
        private float countdown = 0f;

        //���̺� ī��Ʈ
        private int waveCount = 0;

        //�ؽ�Ʈ UI
        public TextMeshProUGUI countdownText;
        //�������̸� true, �ƴϸ� false
        bool isSpawn = false;       //
        #endregion


        // Start is called before the first frame update
        void Start()
        {
            //�ʱ�ȭ - ���۽� ��� �ð�
            countdown = 2f;
            waveCount = 0;

            //�������� ��ġ��  Enemy 1���� ����
            //SpawnEnemy();
        }

        // Update is called once per frame
        void Update()
        {
            /*countdown += Time.deltaTime;
            Debug.Log($"countdown: {countdown}");
            if(countdown >= spawnTimer)
            {
                //Ÿ�̸� ���
                Debug.Log($"enemy ����");

                //�ʱ�ȭ
                countdown = 0;
            }*/
            if (countdown <= 0f)
            {
                //Ÿ�̸� ���
                StartCoroutine(SpawnWave());

                //�ʱ�ȭ
                countdown = spawnTimer;
            }

            if (isSpawn == false)
            {
                countdown -= Time.deltaTime;
                countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            }
            //UI            
            countdownText.text = Mathf.Round(countdown).ToString();

        }

        //�������� ��ġ�� Enemy�� ����
        private void SpawnEnemy()
        {
            Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
            //Instantiate(enemyPrefab);
        }

        //���̺� �Ҷ����� 1������ �߰� ����  1 - 2 - 3 - 4 - 5..
        IEnumerator SpawnWave()
        {
            isSpawn = true;

            waveCount++;
            //Debug.Log($"waveCount: {waveCount}");

            for (int i = 0; i < waveCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }

            isSpawn = false;
        }
    }
}

/*
����Ƽ�� �ʵ� �ʱ�ȭ
1. ���� ����� �� �ʱ�ȭ         spawnTimer = 5f;
2. public �� ������ �ν����� â���� �� �ʱ�ȭ  spawnTimer = 3f;
3. Start() �Լ����� ���� �� �ʱ�ȭ    spawnTimer = 4f;
spawnTimer : 5f -> 3f -> 4f
*/