using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string loadToScene = "PlaySceneStudy";
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
        SceneManager.LoadScene(loadToScene);
    }
    public void OnClickQuit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
