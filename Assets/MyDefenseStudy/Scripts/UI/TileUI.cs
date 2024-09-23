using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    public Button upgradeButton;
    public Button sellButton;
    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI sellText;
    GameObject tileUI;
    BuildManager bm;
    
    // Start is called before the first frame update
    void Start()
    {
        bm = BuildManager.instance;
        tileUI = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickUpgrade()
    {
        Debug.Log("Upgrade");
        bm.targetTile.GetComponent<TileController>().UpgradeTurret();
        HideTileUI();
    }
    public void OnClickSell()
    {
        Debug.Log("Sell");
        bm.targetTile.GetComponent<TileController>().SellTurret();
        HideTileUI();
    }

    public void ShowTileUI()
    {
        tileUI.SetActive(true);
        tileUI.transform.position = bm.targetTile.transform.position + new Vector3(0, 3f, 1f);
        //upgradeText.text = $"Upgrade\n{bm.GetTurretToBuild().upgradeCost}G";
        //sellText.text = $"Sell\n{bm.GetTurretToBuild().cost / 2}G";
    }

    public void HideTileUI()
    {
        tileUI.SetActive(false);
        bm.targetTile = null;
    }
}