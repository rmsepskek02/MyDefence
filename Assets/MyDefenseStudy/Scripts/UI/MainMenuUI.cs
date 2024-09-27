using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField] private string loadToScene = "LevelSelect";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlay()
    {
        fader.FadeTo(loadToScene);
    }
    public void OnClickQuit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
