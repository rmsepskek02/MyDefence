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
    public GameObject tileUI;
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
        tileUI.transform.position = bm.targetTile.transform.position + new Vector3(0, 1f, 2f);
        TileController tc = bm.targetTile.GetComponent<TileController>();

        TurretBlueprint turret = bm.GetTurretToBuild();
        if (tc.UpgradeStep > 1)
        {
            upgradeText.text = $"Upgrade\nDone";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeText.text = $"Upgrade\n{tc.turretBlueprint.upgradeCost}G";
        }
        sellText.text = $"Sell\n{tc.turretBlueprint.GetSellCost()}G";
    }

    public void HideTileUI()
    {
        tileUI.SetActive(false);
        bm.targetTile = null;
    }
}