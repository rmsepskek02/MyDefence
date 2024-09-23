using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    public GameObject targetTile;
    public GameObject tileUIgo;
    TileUI tileUI;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        tileUI = tileUIgo.GetComponent<TileUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        tileUI.HideTileUI();
    }

    public void SetTile(GameObject tileGo)
    {
        if (tileGo == targetTile)
        {
            tileUI.HideTileUI();
        }
        else
        {
            targetTile = tileGo;
            tileUI.ShowTileUI();
            turretToBuild = null;
        }
    }
}
