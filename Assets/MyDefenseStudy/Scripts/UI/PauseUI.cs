using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public SceneFader fader;
    public GameObject pauseUI;
    public Button continueButton;
    public Button retryButton;
    public Button menuButton;
    private string loadToScene = "MainMenuScene";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.gameObject.SetActive(!pauseUI.gameObject.activeSelf);
            if(pauseUI.gameObject.activeSelf == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void OnClickContinue()
    {
        pauseUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnClickRetry()
    {
        pauseUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }
    public void OnClickMenu()
    {
        pauseUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        fader.FadeTo(loadToScene);
    }
}
