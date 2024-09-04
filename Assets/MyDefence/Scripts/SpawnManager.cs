using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyDefence
{
    //Enemy 스폰을 관리하는 클래스
    public class SpawnManager : MonoBehaviour
    {
        //필드
        #region Variable
        //enemy 프리팹
        public GameObject enemyPrefab;
        //스폰 위치(시작 위치)
        public Transform startPoint;

        //스폰 타이머
        public float spawnTimer = 5f;
        private float countdown = 0f;

        //웨이브 카운트
        private int waveCount = 0;

        //텍스트 UI
        public TextMeshProUGUI countdownText;
        //스폰중이면 true, 아니면 false
        bool isSpawn = false;       //
        #endregion


        // Start is called before the first frame update
        void Start()
        {
            //초기화 - 시작시 대기 시간
            countdown = 2f;
            waveCount = 0;

            //시작지점 위치에  Enemy 1개를 생성
            //SpawnEnemy();
        }

        // Update is called once per frame
        void Update()
        {
            /*countdown += Time.deltaTime;
            Debug.Log($"countdown: {countdown}");
            if(countdown >= spawnTimer)
            {
                //타이머 명령
                Debug.Log($"enemy 생성");

                //초기화
                countdown = 0;
            }*/
            if (countdown <= 0f)
            {
                //타이머 명령
                StartCoroutine(SpawnWave());

                //초기화
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

        //시작지점 위치에 Enemy를 생성
        private void SpawnEnemy()
        {
            Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
            //Instantiate(enemyPrefab);
        }

        //웨이브 할때마다 1마리씩 추가 스폰  1 - 2 - 3 - 4 - 5..
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
유니티의 필드 초기화
1. 변수 선언시 값 초기화         spawnTimer = 5f;
2. public 을 선언후 인스펙터 창에서 값 초기화  spawnTimer = 3f;
3. Start() 함수에서 변수 값 초기화    spawnTimer = 4f;
spawnTimer : 5f -> 3f -> 4f
*/