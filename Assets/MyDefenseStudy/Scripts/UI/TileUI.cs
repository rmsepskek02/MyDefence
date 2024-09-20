using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    public static TileUI Instance;
    public Button upgradeButton;
    public Button sellButton;
    public static GameObject tileUI;
    public static GameObject mapTile;
    // Start is called before the first frame update
    void Start()
    {
        tileUI = gameObject;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickUpgrade()
    {
        Debug.Log("Upgrade");
    }
    public void OnClickSell()
    {
        Debug.Log("Sell");
    }
}
