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
    public static int nowLevel;
    public Canvas GameOverUI;
    public SceneFader fader;
    public Button RetryButton;
    public Button MenuButton;
    public TextMeshProUGUI roundText;
    [SerializeField] private string loadToMenu = "MainMenuScene";
    [SerializeField] private string loadToScene = "Level";
    //[SerializeField] private int unlockLevel = 2;
    //[SerializeField] private string keyName = "NowLevel";
    //public Transform contents;
    //private Button[] levelButtons;
    //[SerializeField] private string loadScene = "Level2";

    #endregion
    private void OnEnable()
    {
        roundText.text = PlayerStats.Round + "Round(" + PlayerStats.Wave + ")";
    }

    private void Start()
    {
        isGameOver = false;
        GameOverUI.gameObject.SetActive(false);
        nowLevel = int.Parse(SceneManager.GetActiveScene().name.Replace("Level", ""));

        //levelButtons = new Button[contents.childCount];

        //for (int i = 0; i < levelButtons.Length; i++)
        //{
        //    Transform child = contents.GetChild(i);
        //    levelButtons[i] = child.GetComponent<Button>();
        //    if (i < nowLevel)
        //    {
        //        levelButtons[i].interactable = true;
        //    }
        //}
    }

    //public void LevelClear()
    //{
    //    int nowLevel = PlayerPrefs.GetInt(keyName, 1);
    //    if(nowLevel < unlockLevel)
    //    {
    //        PlayerPrefs.SetInt(keyName , unlockLevel);
    //    }
    //    fader.FadeTo(loadScene);
    //}

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void OnClickRetry()
    {
        GameOverUI.gameObject.SetActive(false);
        fader.FadeTo(SceneManager.GetActiveScene().name);
        Debug.Log("RETRY");
    }
    public void OnClickMenu()
    {
        GameOverUI.gameObject.SetActive(false);
        fader.FadeTo(loadToMenu);
        Debug.Log("MENU");
    }
    public void OnClickContinue()
    {
        fader.FadeTo(loadToScene + (nowLevel + 1).ToString());
    }
}

