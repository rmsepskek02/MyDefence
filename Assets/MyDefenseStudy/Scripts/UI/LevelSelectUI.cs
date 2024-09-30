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
    public GameObject Buttons;
    [SerializeField] private string loadToScene = "Level";
    public Scrollbar scrollbar;
    public RectTransform scrollView;
    // Start is called before the first frame update
    void Start()
    {
        maxLevel = 100;
        currentLevel = PlayerPrefs.GetInt("nowLevel", 1);
        InstantiateButton();

        // 정수값 구하기
        float contentsHeight = 110 + (int)((Buttons.transform.childCount - 1) / 5) * (110+5);
        float scrollHeight = contentsHeight - scrollView.rect.height;
        if (scrollHeight > 0)
        {
            float levelHeight = (int)(currentLevel / 5) * (110 + 5);
            scrollbar.value = 1 - levelHeight / scrollHeight;
            if(scrollbar.value < 0f)
            {
                scrollbar.value = 0f;
            }
        }
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
            btnGo.onClick.AddListener(() => OnButtonClicked(level));
        }
    }

    // 버튼 클릭 시 호출되는 메서드
    void OnButtonClicked(int lv)
    {
        Debug.Log($"Level {lv} Click!!");
        fader.FadeTo(loadToScene+lv.ToString());
    }
}

/*
 게임데이터 SAVE/LOAD
 - 로컬(디바이스) : 파일
 - 서버 : 데이터베이스
 */
