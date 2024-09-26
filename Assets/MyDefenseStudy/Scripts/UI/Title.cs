using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private string loadToScene = "MainMenuScene";
    [SerializeField] private float anykeyDelay = 3.0f;
    [SerializeField] private float menuDelay = 10.0f;
    public TextMeshProUGUI anyKey;
    public SceneFader fader;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelaySeconds");
        anyKey.gameObject.SetActive(false);
        //Invoke("ActivePressAnyKey", anykeyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (anyKey.gameObject.activeSelf == false) return;
        if(Input.anyKeyDown)
        {
            fader.FadeTo(loadToScene);
            StopAllCoroutines();
            return;
        }
    }
    void ActivePressAnyKey()
    {
        anyKey.gameObject.SetActive(true);
    }

    IEnumerator DelaySeconds()
    {
        yield return new WaitForSeconds(anykeyDelay);
        anyKey.gameObject.SetActive(true);
        yield return new WaitForSeconds(menuDelay);
        fader.FadeTo(loadToScene);
    }
}
