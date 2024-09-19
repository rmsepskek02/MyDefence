using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//게임의 전체 진행을 관리하는 클래스
public class GameManager : MonoBehaviour, IPointerEnterHandler
{
    #region Variables
    //게임오버 체크
    private bool isGameOver = false;
    public Canvas GameOverUi;
    public Canvas PauseUi;
    public Button ContinuePButton;
    public Button RetryPButton;
    public Button MenuPButton;
    public Button RetryButton;
    public Button MenuButton;
    Animator animator;
    Animator animatorP;
    public TextMeshProUGUI roundText;
    #endregion

    private void Start()
    {
        GameOverUi.gameObject.SetActive(false);
        PauseUi.gameObject.SetActive(false);
        animator = GameOverUi.GetComponent<Animator>();
        animatorP = PauseUi.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        //게임 오버 체크
        if (PlayerStats.Life <= 0)
        {
            Debug.Log("Game Over");
            isGameOver = true;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerStats.AddMoney(100000);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameOverUi.gameObject.SetActive(true);
            //animator.Play("GameOverAnim");
        }
        roundText.text = PlayerStats.Round + "Round(" + PlayerStats.Wave + ")";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUi.gameObject.SetActive(true);
            //Time.timeScale = 0f;
            //animatorP.speed = 1f;
        }
    }

    public void OnClickRetry()
    {
        GameOverUi.gameObject.SetActive(false);
        Debug.Log("RETRY");
    }
    public void OnClickMenu()
    {
        GameOverUi.gameObject.SetActive(false);
        Debug.Log("MENU");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (animator != null)
        {
            Debug.Log("MENUENTER");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (animator != null)
        {
            Debug.Log("MENUEXIT");
        }
    }
    public void OnClickContinueP()
    {
        PauseUi.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("CONTINUEP");
    }
    public void OnClickRetryP()
    {
        PauseUi.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("RETRYP");
    }
    public void OnClickMenuP()
    {
        PauseUi.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("MENUP");
    }
}
