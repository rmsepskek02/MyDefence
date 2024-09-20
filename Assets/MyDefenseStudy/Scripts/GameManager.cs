using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//게임의 전체 진행을 관리하는 클래스
public class GameManager : MonoBehaviour
{
    #region Variables
    //게임오버 체크
    private static bool isGameOver = false;
    public static bool IsGameOver => isGameOver;
    public Canvas GameOverUI;
    
    public Button RetryButton;
    public Button MenuButton;
    public TextMeshProUGUI roundText;
    #endregion
    private void OnEnable()
    {
        roundText.text = PlayerStats.Round + "Round(" + PlayerStats.Wave + ")";
    }

    private void Start()
    {
        isGameOver = false;
        GameOverUI.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        //게임 오버 체크
        if (PlayerStats.Life <= 0)
        {
            GameOverUI.gameObject.SetActive(true);
            isGameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerStats.AddMoney(100000);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameOverUI.gameObject.SetActive(true);
            isGameOver = true;
        }
    }
    public void OnClickRetry()
    {
        GameOverUI.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("RETRY");
    }
    public void OnClickMenu()
    {
        GameOverUI.gameObject.SetActive(false);
        Debug.Log("MENU");
    }
}
