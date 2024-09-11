using UnityEngine;

namespace MyDefence
{
    //플레이어의 속성을 관리하는 클래스
    public class PlayerStats : MonoBehaviour
    {
        #region Variables
        //소지금
        private static int money;
        //소지금 읽기 전용 속성
        public static int Money
        {
            get { return money; }
        }
        //게임 시작시 지급하는 초기 소지금
        [SerializeField] private int startMoney = 400;
        #endregion

        private void Start()
        {
            //초기화
            money = startMoney;
            Debug.Log($"소지금 {money}를 지급하였습니다");
        }

        //돈을 번다
        public static void AddMoney(int amount)
        {
            money += amount;
        }

        //돈을 쓴다
        public static bool UseMoney(int amount)
        {
            //소지금 체크
            if (!HasMoney(amount))
            {
                Debug.Log("소지금이 부족합니다");
                return false;
            }

            money -= amount;
            return true;
        }

        //소지금 잔금 확인
        public static bool HasMoney(int amount)
        {
            return money >= amount;
        }


    }
}
