using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    public SceneFader fader;
    public float maxLevel;
    public int currentLevel;
    public Button lvButton;
    public Transform buttonParent;
    public ScrollRect scrollRect;
    //public Button currentLvButton;
    [SerializeField] private string loadToScene = "Level";
    // Start is called before the first frame update
    void Start()
    {
        maxLevel = 100;
        currentLevel = PlayerPrefs.GetInt("nowLevel", 11);
        InstantiateButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateButton()
    {
        for(int i = 0; i < maxLevel; i++)
        {
            Button btnGo = Instantiate(lvButton, buttonParent);
            TextMeshProUGUI btnText = btnGo.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            btnText.text = $"{(i + 1)}";
            int level = i + 1;
            if(currentLevel < level)
            {
                btnGo.interactable = false;
            }
            if(currentLevel == level)
            {
                Debug.Log("TEST = " + currentLevel + ", " + level);
                //currentLvButton = btnGo;
            }
            btnGo.onClick.AddListener(() => OnButtonClicked(level));
        }

        // TODO 스크롤 하는법
        //float targetPos = (currentLvButton.transform.localPosition.y / scrollRect.content.rect.height);
        //scrollRect.normalizedPosition = new Vector2(0, 1 - targetPos);
    }

    // 버튼 클릭 시 호출되는 메서드
    void OnButtonClicked(int lv)
    {
        Debug.Log($"Level {lv} Click!!");
        fader.FadeTo(loadToScene+lv.ToString());
    }
}
