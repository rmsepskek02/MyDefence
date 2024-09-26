using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image faderImage;
    public AnimationCurve animationCurve;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeTo(string SceneName)
    {
        StartCoroutine(FadeOut(SceneName));
    }

    IEnumerator FadeIn()
    {
        // 1초동안 image a 1 -> 0
        float t = 2;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = animationCurve.Evaluate(t);
            faderImage.color = new Color(0f, 0f, 0f, a);
            
            yield return 0f;
        }
    }
    IEnumerator FadeOut(string SceneName)
    {
        // 1초동안 image a 0 -> 1
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = animationCurve.Evaluate(t);
            faderImage.color = new Color(0f, 0f, 0f, t);

            yield return 0f;
        }

        // 다음씬 로드
        SceneManager.LoadScene(SceneName);
    }
}
