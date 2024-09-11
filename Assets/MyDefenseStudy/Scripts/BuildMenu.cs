using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    private BuildManager bm;
    public TurretBlueprint basicTurret;
    public TurretBlueprint missileLauncher;
    public TextMeshProUGUI basicTurretGold;
    public TextMeshProUGUI missileLauncherGold;
    public TestChild test;
    // Start is called before the first frame update
    void Start()
    {
        basicTurretGold.text = basicTurret.cost.ToString() + " G";
        missileLauncherGold.text = missileLauncher.cost.ToString() + " G";
    }

    // Update is called once per frame
    void Update()
    {
        bm = BuildManager.instance;
    }
    public void OnClickTurret()
    {
        Debug.Log("SELECT TURRET");
        bm.SetTurretToBuild(basicTurret);
    }
    public void OnClickMissileLauncher()
    {
        Debug.Log("SELECT ANOTHER TURRET");
        bm.SetTurretToBuild(missileLauncher);
    }
}
