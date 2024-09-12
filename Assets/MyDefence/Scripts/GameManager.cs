using UnityEngine;

namespace MyDefence
{
    //게임의 전체 진행을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Variables
        //게임오버 체크
        private bool isGameOver = false;
        #endregion

        // Update is called once per frame
        void Update()
        {
            if (isGameOver)
                return;

            //.....

            //게임 오버 체크
            if(PlayerStats.Lives <= 0)
            {
                Debug.Log("Game Over");
                isGameOver = true;
            }
        }
    }
}