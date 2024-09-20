using UnityEngine;

namespace MyDefence
{
    //게임의 전체 진행을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크
        private static bool isGameOver = false;
        public static bool IsGameOver => isGameOver;

        //게임오버 UI
        public GameObject gameoverUI;

        //치팅 체크
        private bool isCheating = true;
        #endregion

        private void Start()
        {
            //초기화
            isGameOver = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (isGameOver)
                return;

            //.....

            //게임 오버 체크
            if(PlayerStats.Lives <= 0)
            {
                GameOver();
            }

            //치팅
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }
            if (Input.GetKeyDown(KeyCode.O) && isCheating)
            {
                GameOver();
            }
        }

        void GameOver()
        {
            isGameOver = true;
            //UI창 활성화
            gameoverUI.SetActive(true);

            //벌..
        }

        //머니 치팅 - 10만 골드 지급
        void ShowMeTheMoney()
        {
            if (isCheating == false)
                return;

            PlayerStats.AddMoney(100000);
        }

        //레벨업 치팅 - 100
        void Levelup100()
        {
            if (isCheating == false)
                return;

            //level += 100;
        }

        //....

    }
}