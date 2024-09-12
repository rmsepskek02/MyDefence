using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrawLifeUI : MonoBehaviour
{
    public TextMeshProUGUI lifeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = $"Life : {PlayerStats.Life}";
    }
}
