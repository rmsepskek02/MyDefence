using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace MyDefence
{
    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI roundsText;
        #endregion

        private void OnEnable()
        {
            roundsText.text = PlayerStats.Rounds.ToString();
        }

        public void Retry()
        {
            //SceneManager.LoadScene("PlayScene");  //씬이름으로 로드하기
            //SceneManager.LoadScene(0);            //씬 빌드번호로 로드하기
            //현재씬 불러오기
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            Debug.Log("Goto Menu");
        }
    }
}