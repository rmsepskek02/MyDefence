using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    public static TileUI instance;
    public Button upgradeButton;
    public Button sellButton;
    public static GameObject tileUI;
    public static GameObject mapTile;
    public Animator animator;
    public TurretBlueprint testobj;
    BuildManager bm;
    TurretBlueprint turretBlueprint;
    GameObject turretObj;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tileUI = gameObject;
        animator = GetComponent<Animator>();
        bm = BuildManager.instance;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickUpgrade()
    {
        Debug.Log("Upgrade");
        bm.SetTurretToBuild(testobj);
        turretBlueprint = bm.GetTurretToBuild();
        PlayerStats.UseMoney(turretBlueprint.cost);
        turretObj = Instantiate(turretBlueprint.turretPrefab, mapTile.transform.position, Quaternion.identity);
    }
    public void OnClickSell()
    {
        Debug.Log("Sell");
    }
}
